    using (var client = new WebClient())
    {
        string html = client.DownloadString("url");
        string src = ... //find iframe tag with regex
        string iframe = client.DownloadString(src);
    }
