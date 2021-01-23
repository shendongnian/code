    const long million = 1000*1000;
    private static void CheckValuesZeroToMaxInt()
    {
        object maxValueLock = new object();
        int maxValue = int.MinValue;
        Parallel.For(0, (int.MaxValue / million) + 1, i =>
        {
            int privateMaxValue = int.MinValue;
            for (long j = i * million; j < (i+1) * million && j < int.MaxValue; j++)
            {
                int tmpMaxValue = ComplexMath(j);
                if (tmpMaxValue > privateMaxValue)
                {
                    privateMaxValue = tmpMaxValue;
                }
            }
            lock(maxValueLock)
            {
                if (privateMaxValue > maxValue)
                    maxValue = privateMaxValue;
            }
        }
        Console.WriteLine(maxValue);
    }
