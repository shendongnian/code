    var feed = XDocument.Load(rssFeed.GetResponse().GetResponseStream());
    var items = (from e in feed.Root.Elements("item")
                 select new RssFeedItem
                            {
                                ChannelId = (int?)e.Element("channel_Id") ?? -1,
                                Description = (string)e.Element("description"),
                                // ...
                            }).ToList();
