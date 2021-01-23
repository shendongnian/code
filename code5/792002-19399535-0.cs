    var items = xmlFile.Descendants("item")
                       .Select(x => new Item()
                           {
                               SourcePath = x.Attribute("source").ToString(),
                               DestinationPath = x.Attribute("destination").ToString(),
                               IgnoredSubitems = new List<Ignore>(
                                  x.Elements("ignore")
                                   .Select(y => new Ignore(
                                       path: y.Value,
                                       mode: GetEnumValue<IgnoreMode>((string)y.Attribute("mode")),
                                       pattern: GetEnumValue<IgnorePattern>((string)y.Attribute("style"))
                                    ))
                                )
                            })
                        .ToList();
