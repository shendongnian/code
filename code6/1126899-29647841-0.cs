    [Test]
    public void Test()
    {
        var timer = new Stopwatch();
        timer.Start();
        for (int i = 0; i < 1000; i++)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {
                // do nothing
            }
        }
        timer.Stop();
        Console.WriteLine(timer.ElapsedTicks);
        timer.Reset();
        timer.Start();
        for (int i = 0; i < 1000; i++)
        {
            try
            {
                // do nothing
            }
            catch (Exception)
            {
                // do nothing
            }
        }
        timer.Stop();
        Console.WriteLine(timer.ElapsedTicks);
    }
