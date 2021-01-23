    using (var client = new WebClient())
    {
        string html = client.DownloadString("url");
        string src = ... //find iframe source with regex
        string iframe = client.DownloadString(src);
    }
