    static void FindPrime(long p)
    {
        long max = (long)Math.Ceiling(Math.Sqrt(p));
        foreach (long n in list)
        {
            if (n > max) 
            {
                break;
            }
            else if (p % n == 0)
            {
                return;
            }
        }
        
        list.Add(p);
    }
