using System;
using UnityEngine;
using DRG.Math;

public class MathUtilsPerformance : MonoBehaviour
{
    private enum MathFunction
    {
        Abs,
        Approximately
    }

    [SerializeField]
    private bool UseDefault = true;

    [SerializeField]
    private MathFunction MathFunctionSelected;

    private void Approximately()
    {
        bool b;
        if (UseDefault)
        {
            b = Mathf.Approximately(-1f, -10 / 10);
            return;
        }

        b = MathUtils.Approximately(-1f, -10 / 10);
    }

    private void Abs()
    {
        float f;
        if (UseDefault)
        {
            f = Mathf.Abs(-1f);
            return;
        }

        f = MathUtils.Abs(-1f);
    }

    private void Update()
    {
        Action action;


        switch (MathFunctionSelected)
        {
            case MathFunction.Abs:
                action = Abs;
                break;

            case MathFunction.Approximately:
                action = Approximately;
                break;

            default:
                throw new NotImplementedException();
        }

        for (int i = 0; i < 100000; i++)
        {
            action();
        }
    }
}
