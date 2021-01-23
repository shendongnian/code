    public static bool Isprime(long i)
    {
        if (i < 2)
        {
            return false;
        }
        else if (i < 4)
        {
            return true;
        }
        else if ((i & 1) == 0)
        {
            return false;
        }
        else if (i < 9)
        {
            return true;
        }
        else if (i % 3 == 0)
        {
            return false;
        }
        else
        {
            double r = Math.Floor(Math.Sqrt(i));
            int f = 5;
            while (f <= r)
            {
                if (i % f == 0) { return false; }
                if (i % (f + 2) == 0) { return false; }
                f = f + 6;
            }
            return true;
        }  
    }
