    static void Main(string[] args)
    {
        ServicePointManager.DefaultConnectionLimit = 1000;
    
        var uris = File.ReadAllLines(@"C:\urls.txt").Select(x => new Uri(x));
    
        foreach(var uri in uris)
        {
            var client = new HttpClient();
            var url = uri.ToString();
    
            var task = client.GetStringAsync(uri);
            task.ContinueWith(t => Console.WriteLine("Done {0}", url), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => Console.WriteLine("Failed {0}", url), TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t => Console.WriteLine("Cancelled {0}", url), TaskContinuationOptions.OnlyOnCanceled);
        }
    
        Console.ReadKey();
    }
