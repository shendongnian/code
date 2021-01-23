    for (int j = 0; j < 10; ++j)
    {
        Stopwatch sw = Stopwatch.StartNew();
        Parallel.For(0, height, (a) =>
        {
            int sum = 0;
            for (var i = width * a + 1; i < width * (a + 1); i++)
            {
                ar[i] = (sum += ar[i]);
            }
        });
        Console.WriteLine("This took {0:0.0000}s", sw.Elapsed.TotalSeconds);
    }
