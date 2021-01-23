    // read in the existing rss xml
    var rssFeedXml = XDocument.Load(@"c:\temp\rss.xml"); // replace with Server.MapPath etc.
    var feed = SyndicationFeed.Load(rssFeedXml.CreateReader());            
    var items = new List<SyndicationItem>(feed.Items);
    feed.Items = items;
    // add the new item
    items.Add(
            new SyndicationItem(
            "some title...here ",
            "some description here",
            new Uri("http://example.come")));
            
    // write the xml back out
    var rssFormatter = new Rss20FeedFormatter(feed, false);
    XDocument output = new XDocument();
    using (var xmlWriter = output.CreateWriter())
        rssFormatter.WriteTo(xmlWriter);
    output.Save(@"c:\temp\rss.xml");
