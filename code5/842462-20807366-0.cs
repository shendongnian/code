    var xn = XName.Get("Mappings", doc.Root.GetDefaultNamespace().ToString());
    var mappingsNode = doc.Descendants(xn).Descendants().First();
    var mappingDoc = XDocument.Parse(mappingsNode.ToString());
    xn = XName.Get("MappingFragment", mappingDoc.Root
                                                .GetDefaultNamespace().ToString());
    var mappings = mappingDoc
                .Descendants(xn)
                .Select(x => new
                    {
                        Entity = x.Attribute("StoreEntitySet").Value,
                        Mapping = x.Descendants()
                                    .Select(d => new 
                                                { 
                                                  Property = d.Attribute("Name")
                                                              .Value,
                                                  Column = d.Attribute("ColumnName")
                                                            .Value
                                                })
                    });
