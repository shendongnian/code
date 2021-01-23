                var items = from item in Xml.Descendants("item")
                            select new Item
                            {
                                Name = item.Element("name").Value,
                                ImagesUrl = item.Elements()
                                                .Where(e => e.Name.LocalName.StartsWith("img"))
                                                .Select(e => e.Value)
                                                .ToList()
                };       
