            var feed = new SyndicationFeed(Config.Title, Config.Description, new Uri(Config.Link), Config.ListUrl, DateTime.Now)
            {
                ImageUrl = new Uri(Config.ImageUrl),
                Generator = GetType().BaseType.FullName + "Generator"
            };
            feed.AttributeExtensions.Add(new XmlQualifiedName(RssNs, XNamespace.Xmlns.NamespaceName), Url);
