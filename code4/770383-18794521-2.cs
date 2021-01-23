    HtmlAgilityPack.HtmlDocument doc= new HtmlAgilityPack.HtmlDocument(); htmlDoc.LoadHtml(stringWithHtml);        
      var names = doc.DocumentNode.DescendantNodes().Where(n => n.Name == "td").Where(x => x.Attributes["class"].Value == "sivo");
        var links = doc.DocumentNode.DescendantNodes().Where(n => n.Name == "td").Where(x => x.Attributes["class"].Value == "sivo").Select(x => x.DescendantNodes().Where(s => s.Name == "a"));
        foreach (var item in names)
        {
            var blabla = item.InnerText;
        }
        foreach (var item in links)
        {
            var lnks = item.Select(x => x.Attributes["href"].Value);//links
            var times = item.Select(x => x.InnerText);  //times
        }
