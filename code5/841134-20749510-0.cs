    using (var client = new WebClient())
    {
        try
        {
            //Add your user agent of choice. This is mine, just as an example.
            client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_9_1) AppleWebKit/537.73.11 (KHTML, like Gecko) Version/7.0.1 Safari/537.73.11");
            Console.WriteLine(client.DownloadString("http://oz.by/books/more10176026.html"));
        }
        catch (Exception e)
        {
            throw;
        }
    }
