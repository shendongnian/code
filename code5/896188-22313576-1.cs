    Int i =1;
    String item = String.Empty;
    foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//td"))
    {
        if(i =<5)
        {
          item += node.ChildNodes[0].InnerHtml.Trim();
          i++;
        }
        if (i == 5)
        {
          lstResults.Items.Add(item);
          i = 0;
        }
    }
