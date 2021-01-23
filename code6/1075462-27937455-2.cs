            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result);
            var selectNodes = doc.DocumentNode.SelectNodes("//li[@class='g']");
            foreach (var node in selectNodes)
            {
               //node.InnerText will give you the text content of the li tags ...
            } 
