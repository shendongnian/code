    public static void Main(string[] args)
    {
        int width = 4096;
        int height = 4096;
        int[] ar = new int[width * height];
        Random rnd = new Random(213);
        for (int i = 0; i < ar.Length; ++i)
        {
            ar[i] = rnd.Next(0, 120);
        }
        // (5)...
        for (int j = 0; j < 10; ++j)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            for (int i = 0; i < ar.Length; ++i)  // (3) sequential access
            {
                if ((i % width) == 0)
                {
                    sum = 0;
                }
                // (1) --> the JIT will notice this won't go out of bounds because [0<=i<ar.Length]
                // (5) --> '+=' is an expression generating a 'dup'; this creates less IL.
                ar[i] = (sum += ar[i]); 
            }
            Console.WriteLine("This took {0:0.0000}s", sw.Elapsed.TotalSeconds);
        }
        Console.ReadLine();
    }
