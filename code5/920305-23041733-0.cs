     var pr = Expression.Parameter(typeof(double), "r");
     var ph = Expression.Parameter(typeof(double), "h");
     Expression<Func<double, double, double>> fgCompiled =
        Expression.Lambda<Func<double, double, double>>(
            Expression.Invoke(
                cubed,
                Expression.Invoke(
                    XTCylinderVolume,
                    pr, ph)),
            pr, ph);
