    using (var client = new WebClient())
    {
        Console.WriteLine("Currently running on thread id: {0}",
                           Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("starting to download {0}", s);
        string result = client.DownloadString((string)s);
        Console.WriteLine("finished downloading {0}", s);
    }
