            XNamespace ytNs = "http://www.w3.org/2005/Atom";
            var youtube = XDocument.Load(key);
            var urls = (from item in youtube.Elements(ytNs + "feed").Elements(ytNs + "entry")
                        select new
                            {
                                soundName = item.Element(ytNs + "title").ToString(),
                                url = item.Element(ytNs + "id").ToString(),
                            });
