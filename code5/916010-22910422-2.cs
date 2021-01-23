    WebRequest.DefaultWebProxy = null;
    using (WebClient wc = new WebClient())
    {
        string html = wc.DownloadString("http://checkip.dyndns.org");
        Console.WriteLine(XDocument.Parse(html).Root.Element("body").Value);
    }
    
    WebRequest.DefaultWebProxy = new WebProxy("219.93.183.106", 8080);
    using (WebClient wc = new WebClient())
    {
        string html = wc.DownloadString("http://checkip.dyndns.org");
        Console.WriteLine(XDocument.Parse(html).Root.Element("body").Value);
    }
