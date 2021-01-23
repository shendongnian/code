    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    public static int GetPrime(int min)
    {
        if (min < 0)
        {
            throw new ArgumentException(Environment.GetResourceString("Arg_HTCapacityOverflow"));
        }
        for (int i = 0; i < primes.Length; i++)
        {
             int num2 = primes[i];
             if (num2 >= min)
             {
                 return num2;
             }
        }
        for (int j = min | 1; j < 0x7fffffff; j += 2)
        {
            if (IsPrime(j) && (((j - 1) % 0x65) != 0))
            {
                 return j;
            }
        }
        
        return min;
    }
