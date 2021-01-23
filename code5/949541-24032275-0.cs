    long calculateAverage (long a [])
    {
        long average = 0;
        foreach (long x in a)
            average += (x / a.Length);
        return average;
    }
    long calculateAverage_Safe (long a [])
    {
        long average = 0;
        long b = 0;
        foreach (long x in a)
        {
            b = (x / a.Length);
            if (b >= (long.MaxValue - average)
                throw new OverflowException ();
            average += b;
        }
        return average;
    }
