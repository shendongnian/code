    static void Main()
    {
        while (true)
        {
            new Task(() => Thread.Sleep(int.MaxValue)); // No thread as the task isn't started.
            Task.Delay(-1); // No Timer as the delay is infinite.
        }
    }
