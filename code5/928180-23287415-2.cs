    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
    
        double[] input = Enumerable.Range(0, 10000000).Select(i => (double)i).ToArray();
    
        while (true)
        {
            sw.Start();
    
            LinqStack(input);
    
            sw.Stop();
    
            Console.WriteLine("LinqStack(): {0}ms", sw.ElapsedMilliseconds);
    
            sw.Restart();
    
            SimpleStack(input);
    
            sw.Stop();
    
            Console.WriteLine("SimpleStack(): {0}ms", sw.ElapsedMilliseconds);
    
            sw.Restart();
    
            OriginalStack(input);
    
            sw.Stop();
    
            Console.WriteLine("OriginalStack(): {0}ms", sw.ElapsedMilliseconds);
    
            sw.Reset();
    
            Console.ReadLine();
        }
    }
    
    /// <summary>
    /// By Sriram Sakthivel
    /// </summary>
    static double[] LinqStack(params double[] input)
    {
        return input.Concat(input.Reverse())
                        .ToArray();
    }
    
    static double[] SimpleStack(params double[] input)
    {
        int length = input.Length;
    
        double[] output = new double[length * 2];
    
        for (int i = 0; i < length; i++)
        {
            output[i] = input[i];
        }
    
        for (int i = 0; i < length; i++)
        {
            output[i + length] = input[length - i - 1];
        }
    
        return output;
    }
    
    /// <summary>
    /// By p.s.w.g
    /// </summary>
    static double[] OriginalStack(params double[] input)
    {
        int N = input.Length;        // assuming input = { 1, 2, 3 }
        var z = new double[2 * N];   // z = { 0, 0, 0, 0, 0, 0 }
        input.CopyTo(z, 0);          // z = { 1, 2, 3, 0, 0, 0 }
        input.CopyTo(z, N);          // z = { 1, 2, 3, 1, 2, 3 }
        Array.Reverse(z, N, N);      // z = { 1, 2, 3, 3, 2, 1 }
    
        return z;
    }
