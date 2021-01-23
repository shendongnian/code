    _pages = Configuration.Elements("Pages").Elements()
        .ToDictionary(x => x.Name.LocalName,
            x => x.Descendants("item")
                .Select(y => 
                    new ItemElement
                    {
                        Name = y.Attribute("name").Value,
                        Value = "Value",
                        Origin = "Origin"
                    })
                )
                .ToList();
