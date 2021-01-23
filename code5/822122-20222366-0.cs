    static void Main()
    {
        var inputs = new[] { 
        @"olor:red"">Text</span>",
        @"<span style=""color:red"">Text</span>",
        @"Text</span>",
        @"<span style=""color:red"">Text",
        @"<span style=""color:red"">Text"
        };
        var doc = new HtmlDocument();
        inputs.ToList().ForEach(i => {
            if (!i.StartsWith("<"))
            {
                if (i.IndexOf(">") != i.Length-1)
                    i = "<" + i;
                else
                    i = i.Substring(0, i.IndexOf("<"));
                doc.LoadHtml(i);
                Console.WriteLine(doc.DocumentNode.InnerText);
            }
            else
            {
                doc.LoadHtml(i);
                Console.WriteLine(doc.DocumentNode.OuterHtml);
            }
        });
    }
