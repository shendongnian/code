    var feed = XDocument.Load(rssFeed.GetResponse().GetResponseStream());
    var ns = feed.Root.Name.Namespace;
    var items = (from e in feed.Root.Elements(ns + "item")
                 select new RssFeedItem
                            {
                                ChannelId = (int?)e.Element(ns + "channel_Id") ?? -1,
                                Description = (string)e.Element(ns + "description"),
                                // ...
                            }).ToList();
