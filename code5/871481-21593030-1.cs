    double[] ValuesToCalculate = new double[MAX_SIZE];
    double[] CalculatedCosines = new double[MAX_SIZE];
    long Result;
    Result = CalculateCosineArray(ValuesToCalculate, CalculatedCosines);
    public static long CalculateCosineArraySIMD(double[] array, double[] result)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Yeppp.Math.Cos_V64f_V64f(array, 0, result, 0, MAX_SIZE);
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
