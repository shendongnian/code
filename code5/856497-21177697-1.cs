    var blocks = (from b in xdoc.Descendants("Block")
                     select new Block {
                              Name = (string)b.Attribute("Name"),
                              Attributes = (from a in b.Elements("Attributes")
                                               select new BlockAttribute {
                                                       Tag = (string)a.Element("Tag"),
                                                       Layer = (string)a.Element("Layer")
                                                      }).ToList()
                                        }).ToList();
                        
