    string html = File.ReadAllText(@"C:\Temp\html.txt");
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var result = Enumerable.Empty<string>();
    var firstTD = doc.DocumentNode.SelectNodes("//td").FirstOrDefault();
    if (firstTD != null)
    {
        if (firstTD.Attributes.Contains("onclick"))
        {
            string onclick = firstTD.Attributes["onclick"].Value;
            int newWindowIndex = onclick.IndexOf("newWindow(", StringComparison.OrdinalIgnoreCase);
            if (newWindowIndex >= 0)
            {
                string functionBody = onclick.Substring(newWindowIndex + "newWindow(".Length);
                string[] tokens = functionBody.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                result = tokens.Take(2).Select(s => s.Trim(' ', '\''));
            }
        }
    }
