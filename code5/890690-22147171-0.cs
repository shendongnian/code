    var topics = (from plist in doc.Root.Elements("dict")
                                      select new 
                                      {
                                          MainTitle = plist.Element("string").Value,
                                          ListOfSubTitles = plist.Element("array")
                                                       .Elements("dict")
                                                       .Elements("string")
                                                       .Select(s => s.Value)
                                                       .ToList(),
                                          ListOfIDs = plist.Element("array")
                                                        .Elements("dict")
                                                        .Elements("array")
                                                        .Elements("string")
                                                        .Select(s => s.Value)
                                                        .ToList()
                                      }).ToList();
