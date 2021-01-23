    GeckoElementCollection fblikes = webBrowser.Document.GetElementsByTagName("a");
                foreach (GeckoHtmlElement item in fblikes)
                {
                    string aux = item.GetAttribute("href");
                    if (!string.IsNullOrWhiteSpace(aux) && aux.Equals("p.php?p=facebook"))
                    {
                        item.Click();
                        
                    }
                }
