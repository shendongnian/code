    private static List<FeedsItem> ParseFeeds(string feedsXml)
    {
        XDocument xDoc = XDocument.Parse(feedsXml);
        XNamespace xmlns = "http://www.w3.org/2005/Atom";
        var items = from entry in xDoc.Descendants(xmlns + "entry")
                    select new FeedsItem
                    {
                        Id = (string)entry.Element(xmlns + "id").Value,
                        Title = (string)entry.Element(xmlns + "title").Value,
                        AlternateLink = (string)entry.Descendants(xmlns + "link").Where(link => link.Attribute("rel").Value == "alternate").First().Attribute("href").Value
                    };
        Console.WriteLine("Count = {0}", items.Count());
        foreach(var i in items)
        {
            Console.WriteLine(i);
        }
        return null;
    }
