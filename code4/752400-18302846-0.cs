         HtmlDocument topDocument = LoadDocument("blah.uk");
         IEnumerable<HtmlNode> topLinks = ReadLinks(topDocument, "main_nav");
         foreach (HtmlNode topLink in topLinks) {
             HtmlDocument catDoc = LoadDocument("littletreasurespartybags" + toplink.Attributes["href"].Value);
             IEnumerable<HtmlNode> catLinks = ReadLinks(topDocument, "main_nav");
             foreach (HtmlNode catLink in catLinks) {
                 .....
             }
         }
    }
