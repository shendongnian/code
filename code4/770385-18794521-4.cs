    HtmlAgilityPack.HtmlDocument doc= new HtmlAgilityPack.HtmlDocument(); htmlDoc.LoadHtml(stringWithHtml);        
      var names = doc.DocumentNode.Descendants().Where(n => n.Name == "td").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "sivo");
        var links = doc.DocumentNode.Descendants().Where(n => n.Name == "td").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "sivo").Select(x => x.Descendants().Where(s => s.Name == "a"));
        foreach (var item in names)
        {
            var blabla = item.InnerText;
        }
        foreach (var item in links)
        {
            var lnks = item.Select(x => x.Attributes["href"].Value);//links
            var times = item.Select(x => x.InnerText);  //times
        }
