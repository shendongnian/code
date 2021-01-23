    ICollection<Podcast> SampleData()
    {
        string rssUri = "http://test.test.com/rss";
        var doc = System.Xml.Linq.XDocument.Load(rssUri);
    
        ICollection<Podcast> p = (from el in doc.Elements("rss").Elements("channel").Elements("item")
    
                             select new Podcast
                             {
                                 Title = el.Element("title").Value,
                                 PubDate = el.Element("pubDate").Value,
                                 Enclosure = el.Element("enclosure").Attribute("url").Value,
                                 Description = el.Element("description").Value
                                  }).ToList();
            return p;
        }
