    var result = xdoc.Root.Descendants("Item")
                     .Select(x => new
              {
                 Name = (string)x.Document.Root.Element("Name"),
                 InId = (string)x.Document.Root.Element("InId"),
                 CustomID = (string)x.Document.Root.Element("CustomID"),
                 ItemID = (string)x.Element("ItemID"),
                 ItemName = (string)x.Element("ItemName"),
                 OrdersList = x.Descendants("Order")
                               .Select(y => new
                                  {
                                     IDIndex = (string)y.Element("IDIndex"),
                                     IDParam = (string)y.Element("IDParam"),
                                     ThemesList = y.Descendants("Theme")
                                                   .Select(z => new 
                                                  {
                                                     Status = (string)z.Element("Status"),
                                                     Lastget = (string)z.Element("Lastget")
                                                  }).ToList()
                                   }).ToList()
             });
