    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
    document.LoadHtml(html);
    document.DocumentNode.SelectSingleNode("//body").Descendants()
                    .Where(n => n.Name == "script")
                    .ToList()
                    .ForEach(n => n.Remove());
