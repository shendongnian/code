        public static List<ItemsLoad> GetElements(string response)
        {
            const string Namespace = "http://www.w3.org/2005/Atom";
            var rssFeed = XElement.Parse(response);
            var items = (from item in rssFeed.Elements(XName.Get("entry", Namespace))
                select new ItemsLoad
                {
                    Title = item.Element(XName.Get("title", Namespace)).Value,
                    Link = item.Element(XName.Get("link", Namespace)).Value,
                    Description = item.Element(XName.Get("summary", Namespace)).Value,
                    PubDate = item.Element(XName.Get("published", Namespace)).Value
                });
            return items.ToList();
        }
