    static void Main(string[] args)
    {
        long c = 0;
        var sw = new Stopwatch();
        sw.Start();
        unchecked
        {
            for (long i = 0; i < 500000000; i++) c += 1;
        }
        sw.Stop();
        Console.WriteLine("Unchecked: " + sw.ElapsedMilliseconds);
        c = 0;
        sw.Restart();
        checked
        {
            for (long i = 0; i < 500000000; i++) c += 1;
        }
        sw.Stop();
        Console.WriteLine("Checked: " + sw.ElapsedMilliseconds);
    }
