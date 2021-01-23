        var doc = new HtmlDocument
        {
            OptionOutputAsXml = true,
            OptionCheckSyntax = true,
            OptionFixNestedTags = true,
            OptionAutoCloseOnEnd = true,
            OptionDefaultStreamEncoding = Encoding.UTF8
        };
        doc.LoadHtml(htmlContent);
        var results = new List<string[]>();
        foreach (var node in doc.DocumentNode.SelectNodes("//div"))
        {
            var divContent = node.InnerText;
            if (string.IsNullOrWhiteSpace(divContent))
                continue;
            var lines = divContent.Trim().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            results.Add(lines);
        }
