        System.Text.RegularExpressions.Regex
            dayParseRegex = new System.Text.RegularExpressions.Regex(@"(?<days>\d)( days\))$");
        HtmlAgilityPack.HtmlDocument currentHTML = new HtmlAgilityPack.HtmlDocument();
        HtmlWeb webget = new HtmlWeb();
        currentHTML = webget.Load("http://www.aliexpress.com/item/-/255859073.html");
        //Extract node
        var handlingTimeNode = currentHTML.DocumentNode.SelectSingleNode("//*[@id=\"product-info-shipping-sub\"]");
        
        //Run RegEx against text
        var match = dayParseRegex.Match(handlingTimeNode.InnerText);
        //Convert the days to an integer from the resultant group
        int shippingDays = Convert.ToInt32(match.Groups["days"].Value);
