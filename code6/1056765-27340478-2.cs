    public void GetStates()
    {
        var wc = new WebClient {Proxy = null};
        var webDoc = new HtmlAgilityPack.HtmlDocument();
        webDoc.LoadHtml(wc.DownloadString("http://goo.gl/2R4ne1"));
        foreach (var descendents in webDoc.DocumentNode.SelectNodes("//tr").Skip(1).Take(50)
            .Select(i => i.Descendants("td").ToList()))
            _allStates.Add(new State(descendents[0].InnerText, descendents[1].InnerText));
    }
