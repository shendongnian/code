    using (WebClient wc = new WebClient { Proxy = null })
    {
        string html = wc.DownloadString("http://checkip.dyndns.org");
        Console.WriteLine(XDocument.Parse(html).Root.Element("body").Value);
    }
    
    using (WebClient wc = new WebClient { Proxy = new WebProxy("219.93.183.106", 8080) })
    {
        string html = wc.DownloadString("http://checkip.dyndns.org");
        Console.WriteLine(XDocument.Parse(html).Root.Element("body").Value);
    }
