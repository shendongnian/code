    static void Main(string[] args)
    {
        TimeSpan ts = new TimeSpan();
        TimeSpan ts2 = new TimeSpan();
        TimeSpan ts3 = new TimeSpan();
        TimeSpan ts4 = new TimeSpan();
        TimeSpan ts5 = new TimeSpan();
        TimeSpan ts6 = new TimeSpan();
        TimeSpan ts7 = new TimeSpan();
        TimeSpan ts8 = new TimeSpan();
        Stopwatch sw = new Stopwatch();
        // throw away first run
        for (int i = 0; i < 2; i++)
        {
            sw.Restart();
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                ts = sw.Elapsed;
            }
            sw.Stop();
            ts2 = sw.Elapsed;
            try
            {
                sw.Restart();
                try
                {
                    throw new NotImplementedException();
                }
                finally
                {
                    ts3 = sw.Elapsed;
                }
            }
            catch
            {
                ts4 = sw.Elapsed;
            }
            ts5 = sw.Elapsed;
            sw.Stop();
            try
            {
                sw.Restart();
                try
                {
                    throw new NotImplementedException();
                }
                catch
                {
                    ts6 = sw.Elapsed;
                    throw;
                }
            }
            catch
            {
                ts7 = sw.Elapsed;
            }
            sw.Stop();
            ts8 = sw.Elapsed;
        }
        Console.WriteLine(ts);
        Console.WriteLine(ts2);
        Console.WriteLine(ts3);
        Console.WriteLine(ts4);
        Console.WriteLine(ts5);
        Console.WriteLine(ts6);
        Console.WriteLine(ts7);
        Console.WriteLine(ts8);
        Console.ReadLine();
    }
