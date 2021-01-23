     HtmlDocument doc = new HtmlDocument();
     doc.LoadHtml("YOUR HTML STRING");
     foreach(HtmlNode node in doc.DocumentElement.SelectNodes("//select/option[@selected='selected']")
     {
        string text = node.InnerHtml;                  // "American Samoa, United States Dollar (USD)"
        string value = node.Attributes["value"].Value; // "USD"
     }
