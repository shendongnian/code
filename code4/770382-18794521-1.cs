        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument(); htmlDoc.LoadHtml(stringWithHtml);        
        var names = htmlDoc.DocumentNode.SelectNodes("//td[@class='sivo']");
        var links = htmlDoc.DocumentNode.SelectNodes("//td[@class='sivo']/a");
        foreach (item in nodes)
        {
            Console.WriteLine (item.InnerText); //name
        }
        foreach (item in links)
        {
            Console.WriteLine(item.Attributes["href"].Value);//links
            Console.WriteLine(item.InnerText);  //time
        }
