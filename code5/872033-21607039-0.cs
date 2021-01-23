    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(HtmlCode);
    List<testClass> Results = (from tr in doc.DocumentNode.Descendants("tr")
                    select new testClass(
                               tr.Descendants[0].InnerText,
                               tr.Descendants[1].InnerText
                               )).ToList();
