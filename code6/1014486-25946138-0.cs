    var names = new List<string>();
    .....
    .....
    foreach (HtmlNode nd in doc.DocumentNode.SelectNodes("//li"))
    {
    	names.Add(nd.InnerText.Trim());
    }
