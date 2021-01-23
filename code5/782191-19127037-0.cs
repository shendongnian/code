    static void Main(string[] args)
    {
        BackgroundWorker mainWorker = new BackgroundWorker();
        mainWorker.DoWork += (sender, e) =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(500);
                }
            };
        mainWorker.RunWorkerAsync();
    }
