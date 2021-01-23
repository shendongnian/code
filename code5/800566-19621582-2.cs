    using (var webClient = new WebClient())
    {
        webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        XElement.Parse(webClient.DownloadString(url));
    }
