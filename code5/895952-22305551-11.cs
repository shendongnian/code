    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        var p = new Program();
        int[] tests = new int[] { 1, 10, 100, 1000, 10000 };
        foreach (int n in tests) {
            sw.Start();
            p.Run( n, true, true);
            sw.Stop();
            Console.WriteLine(string.Format("{0}; {1:0.000} msec", n, sw.ElapsedMilliseconds));
            sw.Start();
            p.Run(n, false, true);
            sw.Stop();
            Console.WriteLine(string.Format("{0}: {1:0.000} msec (no throw)", n, sw.ElapsedMilliseconds));
            sw.Start();
            p.Run(n, false, false);
            sw.Stop();
            Console.WriteLine(string.Format("{0}: {1:0.000} msec (no throw, no except)", n, sw.ElapsedMilliseconds));
        }
        Console.WriteLine("Any key to exit...");
        Console.ReadKey();
    }
