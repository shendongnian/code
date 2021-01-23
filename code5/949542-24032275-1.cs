    long calculateAverage (long a [])
    {
        double average = 0;
        foreach (long x in a)
            average += (Convert.ToDouble(x)/Convert.ToDouble(a.Length));
        return Convert.ToInt64(Math.Round(average));
    }
    long calculateAverage_Safe (long a [])
    {
        double average = 0;
        double b = 0;
        foreach (long x in a)
        {
            b = (Convert.ToDouble(x)/Convert.ToDouble(a.Length));
            if (b >= (Convert.ToDouble(long.MaxValue)-average))
                throw new OverflowException ();
            average += b;
        }
        return Convert.ToInt64(Math.Round(average));
    }
