            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(link);
            doc.OptionUseIdAttribute = true;
            doc.OptionFixNestedTags = true;
            string Img=string.Empty ;
            if (doc.DocumentNode != null)
            {
                try {
                    HtmlNode img3 = doc.DocumentNode.SelectSingleNode("//*[@class=\"thumb\"]//img[@src]");
                    Img = img3.Attributes["src"].Value;
                }
                catch {
                    Img = "";
                };
            }
