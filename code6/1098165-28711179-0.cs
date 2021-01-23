        Stopwatch timer = new Stopwatch();
        timer.Start();
        for (int i = 0; i < 20; i++)
        {
            //do here some stuff
            Thread.Sleep(500);
        }
        timer.Stop();
        long ms =  timer.ElapsedMilliseconds;
        Console.WriteLine(ms);
        Console.ReadLine();
