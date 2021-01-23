    for (int i = 0; i < 10; i++)
    {
        Task.Factory.StartNew(() => Console.WriteLine("This is task " + i));
        Thread.SpinWait(20000);
    }
