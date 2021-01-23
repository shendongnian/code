    private static object Boxing()
    {
        Stopwatch s = new Stopwatch();
        int unboxed = 33;
        object boxed = null;
        s.Start();
        for (int i = 0; i < 1000000; i++)
        {
            boxed = unboxed;
        }
        s.Stop();
        var elapsed = s.Elapsed.TotalMilliseconds;
        Console.WriteLine("Boxing time : " + elapsed);
        return boxed;
    }
