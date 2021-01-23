    static void Main(string[] args)
    {
        var values = new int[1024 * 1024];
        Random r = new Random();
        for (int i = 0; i < 1024; i++)
        {
            for (int j = 0; j < 1024; j++)
            {
                values[i * 1024 + j] = r.Next(25);
            }
        }
        int rows = 1024;
        int columns = 1024;
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 100; i++)
        {
            Parallel.For(0, rows, (row) =>
            {
                for (var column = 1; column < columns; column++)
                {
                    values[(row * columns) + column] += values[(row * columns) + column - 1];
                }
            });
        }
        Console.WriteLine(sw.Elapsed);
    }
