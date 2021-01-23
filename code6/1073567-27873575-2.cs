    static void Main(string[] args)
    {
        CountDownEvent countDown = new CountDownEvent();
        while (true) 
        {
            Console.Write("Enter a symbol to research or [ENTER] to exit: ");
            string symbol = Console.ReadLine();
            if (string.IsNullOrEmpty(symbol))
                break;
            countDown.AddCount();
            DownloadDataForStockAsync(symbol).ContinueWith(task => countdown.Signal()) ;
        }
        countDown.Wait();
    }
