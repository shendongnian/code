    var products = XDocument.Load(filename).Root
                    .Elements()
                    .Select(x => new
                    {
                        Product = x.Name.LocalName,
                        Name = (string)x.Element("NAME"),
                        Model = (string)x.Element("MODEL"),
                        Price = (decimal)x.Element("PRICE"),
                        Color = (string)x.Element("COLOR")
                    })
                    .ToList();
