    static void Main(string[] args)
    {
        List<Task> tasks = new List<Task>();
        while (true) 
        {
            Console.Write("Enter a symbol to research or [ENTER] to exit: ");
            string symbol = Console.ReadLine();
            if (string.IsNullOrEmpty(symbol))
                break;
            tasks.Add(DownloadDataForStockAsync(symbol));
        }
        Task.WaitAll(tasks);
    }
