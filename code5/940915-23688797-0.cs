    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(matches);
    string matchResultDivId = "match_results";
    string xpath = String.Format("//div[@id='{0}']/div", matchResultDivId);
    var people = doc.DocumentNode.SelectNodes(xpath).Select(p => p.InnerText);
    foreach(var person in people)
        Console.WriteLine(person);
