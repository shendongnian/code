      private string LookForOrignalPrice(HtmlNode node)
      {
        string text = node.InnerText;
        Match priceMatch = _originalPriceRegex.Match(text);
        if (priceMatch.Success) --> put braces to group the statements
        {
           Console.WriteLine("++++++price is " + priceMatch);
           return priceMatch.Groups[1].Value;
        }
        return null;
      }
