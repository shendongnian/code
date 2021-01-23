    static void Main(string[] args)
    {           
        long a = 65539;
        long[] x = new long[100];
        x[0] = 65539;
        long m = long.MaxValue; // equals to 2^63-1
        for(int i = 1; i < x.Length; i++)
        {
            x[i] = a * x[i - 1];
            if (x[i] < 0)
                x[i] = x[i] + m;
            else
                Console.WriteLine("Random Number {0} is {1}", i, x[i]/(float)m);
        }
    }
