    public void GetStates()
    {
        var wc = new WebClient {Proxy = null};
        var webDoc = new HtmlDocument();
        var html = wc.DownloadString("http://goo.gl/8Mw3ud");
        webDoc.LoadHtml(html);
    
        foreach (var i in webDoc.DocumentNode.SelectNodes("//tr").Skip(1).Take(50))
        {
            _allStates.Add(
                new State(i.Descendants("th").ToList()[0].Descendants("a").ToList()[0].InnerText,
                    i.Descendants("td").ToList()[0].InnerText));
        }
    }
