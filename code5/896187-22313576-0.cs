    Int I =1;
    String item = String.Empty;
    foreach (HtmlNode node inhtmlDocument.DocumentNode.SelectNodes("//td"))
    {
    If(I =<5)
    {
     item += node.ChildNodes[0].InnerHtml.Trim();
    }
    if (I == 5)
    {
     lstResults.Items.Add(item);
     I = 0;
    }
    }
