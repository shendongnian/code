    using (var wc = new WebClient())
                {
                    var page = wc.DownloadString(arguments);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(page);
                    HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//input");
                   if (nodes != null)
                    {
                        foreach (HtmlAgilityPack.HtmlNode data in nodes)
                        {
                           //Do whatever you want........
                         }
                     }
                  } 
