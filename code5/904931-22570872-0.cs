    var RSSdata = from rss in XElement.Parse(e.Result).Descendants("item")
                          select new RSSItem
                          {
                              Title1 = (string)rss.Element("title"),
                              Description1 = (string)rss.Element("description"),
                              Link1 = (string)rss.Element("link"),
                              PubDate1 = (string)rss.Element("pubDate"),
                              Categories = rss.Elements("category")
                                               .Select(x => (string)x)
                                               .ToList();
                          };
