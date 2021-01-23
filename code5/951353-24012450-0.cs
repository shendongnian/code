    static void Main(string[] args)
    {
        DateTime start = DateTime.Now;
        for (int i = 0; i < 10000000; i++)
        {
            Math.Pow(10, 100);
        }
        TimeSpan diff = DateTime.Now - start;
        Console.WriteLine("Normal: {0:N0}", diff.TotalMilliseconds);
        //-------------- efficient
        start = DateTime.Now;
        for (int i = 0; i < 10000000; i++)
        {
            Math.Exp(Math.Log(10) * 100);
        }
        diff = DateTime.Now - start;
        Console.WriteLine("Efficient: {0:N0}", diff.TotalMilliseconds);
        Console.ReadLine();
    }
