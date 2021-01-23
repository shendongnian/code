    private static void CheckValuesZeroToMaxInt()
    {
        object maxValueLock = new object();
        int maxValue = int.MinValue;
        Parallel.For(0, int.MaxValue, i =>
        {
            int tmpMaxValue = ComplexMath(i);
            if (tmpMaxValue > maxValue)
            {
                lock(maxValueLock)
                {
                    if (tmpMaxValue > maxValue)
                        maxValue = tmpMaxValue;
                }
            }
        }
        Console.WriteLine(maxValue);
    }
