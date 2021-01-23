    var xDocument = XDocument.Parse(/* ... */);
    
    var slots =
       xDocument.Descendants("day")
                .SelectMany(day => day.Elements("slot")
                                      .Select(
                                        slot => new
                                          {
                                            DayName = day.Attribute("name").Value,
                                            Name = slot.Element("name").Value,
                                            Number = slot.Attribute("number").Value,
                                            //...
                                          }));
