    new Thread(() =>
    {
        while (true)
        {
            Process[] list = Process.GetProcessesByName("yourProcessName");
            if (list.Length == 0)
                Console.WriteLine("Not running.");
            else
                Console.WriteLine("Running.");
            Thread.Sleep(1000);
        }
    }).Start()
