    private static string GetAttributeFromGroup(SyndicationElementExtensionCollection seec, string elementName, string attributeName) 
    {
        foreach (SyndicationElementExtension extension in seec)
        {
            XElement element = extension.GetObject<XElement>();
            if (element.Name.LocalName == "group") 
            {
                foreach (var item in  element.Elements())
                {
                    if (item.Name.LocalName == elementName) 
                    {
                        return item.Attribute(attributeName).Value;
                    }
                }
            }
        }
        return null;
    }
    
    public static List<YouTubeInfo> LoadVideosKey(string keyWord, int start, int limit)
    {
        try
        {
            switch (search_based)
            {
                case 0: search = SEARCH; break;
                case 1: search = Most_popular; break;
            }
            var xDoc = XmlReader.Create(string.Format(search, keyWord, start, limit));
            SyndicationFeed feed = SyndicationFeed.Load(xDoc);
            var links = (from item in feed.Items
                         select new YouTubeInfo
                         {
                             LinkUrl = item.Id,
                             Title = item.Title.Text,
                             EmbedUrl = item.Links.FirstOrDefault().Uri.AbsoluteUri,
                             ThumbNailUrl = GetAttributeFromGroup(item.ElementExtensions, "thumbnail", "url"),
                             Duration = int.Parse(GetAttributeFromGroup(item.ElementExtensions, "duration", "seconds") ?? "0"),
                         }).Take(limit);
    
            return links.ToList<YouTubeInfo>();
        }
        catch (Exception e)
        {
            Trace.WriteLine(e.Message, "ERROR");
        }
        return null;
    }
