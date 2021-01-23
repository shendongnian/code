    Stopwatch sw = new Stopwatch();
    sw.Start();
    using (WebClient client = new WebClient())
    {
        string response = client.DownloadString("https://www.google.com");
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
