    // load XML into XDocument instance
    var xDoc = XDocument.Load("Input.txt");
    // create new XDocument using info from the loaded one
    var xDoc2 = new XDocument(
                    new XElement("Root",
                        xDoc.Root
                            .Elements("Combination")
                            .Select(c => new XElement("Combination",
                                            c.Attributes(),
                                            c.Elements("Level")
                                             .Select(l => new XElement("Level",
                                                              l.Attributes(),
                                                              l.Elements("Option")
                                                               .OrderBy(o => (DateTime)o.Attribute("Date") + TimeSpan.Parse((string)o.Attribute("Time")))))))
                            .OrderBy(c => c.Elements("Level")
                                           .First(l => (int)l.Attribute("Id") == 1)
                                           .Elements("Option")
                                           .Select(o => (DateTime)o.Attribute("Date") + TimeSpan.Parse((string)o.Attribute("Time")))
                                           .First())
                            
                                           ));
    // save the new document
    xDoc2.Save("Input.txt");
