    public HtmlNode GetDivClass()
    {
        var html = @"<html><div class=""PlainText"">
                DATE: 2013-10-28 20:00:43 -0500 <br/>
                Item 1: Text1 <br/>
                Item 1: Text1 <br/>
                Item 1: Text1 <br/>
                Item 1: Text1 <br/><br   /> //Notice this has two break lines, i would like to stop after seeing two consecutive break lines.
                Item 3
            </div></html>";
        var doc = new HtmlDocument();
        doc.LoadHtml(html);
        return doc.DocumentNode
                    .Descendants("div").First(x => x.Attributes.Contains("class") &&
                                                    x.Attributes["class"].Value.Contains("PlainText"));
    }
       
    public IEnumerable<string> BreakOnConsecutiveBr()
    {                        
        foreach (var n in GetDivClass().ChildNodes)
        {
            if (IsBr(n) && IsBr(n.NextSibling))
            {
                yield break;
            }
            if (n.Name == "#text")
            {
                yield return n.InnerText;
            }
        }
    }
    public bool IsBr(HtmlNode n)
    {
        return n != null && n.NodeType == HtmlNodeType.Element && n.Name == "br";
    }
