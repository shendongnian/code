    var items = from item in xmlDocument.Descendants("item")
                select new Item
                {
                    Name = item.Element("name").Value,
                    ImagesUrl = Enumerable.Range(1,5).Select(x => item.Element("img"+x).Value).ToList();
                };
