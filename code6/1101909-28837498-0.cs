     WebClient wc = new WebClient();
                    string src = wc.DownloadString("http://proxylist.hidemyass.com");
                    HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
                    hd.LoadHtml(src);
                    HtmlAgilityPack.HtmlNode table = hd.DocumentNode.SelectSingleNode("//tr[@class='#altshade']");
                    bool First = false;
                    foreach (HtmlAgilityPack.HtmlNode trs in table.ChildNodes)//.Where(i => i.Name == "tr" && i.InnerText.Trim() != string.Empty))
                    {
                        if (First)
                        {
                            Proxy p = new Proxy();
                            foreach (HtmlAgilityPack.HtmlNode tds in trs.ChildNodes.Where(i => i.InnerText.Trim() != string.Empty))
                            {
                                MessageBox.Show(tds.InnerText);
                            }
                            Proxies.Add(p);
                        }
                        First = true;
                    }
