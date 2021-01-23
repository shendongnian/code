    var listOfLanguages = xDoc.Descendants("LanguageList").Descendants()
                              .Select(l => new
                              {
                                  Name = l.Attribute("name").Value,
                                  Code = l.Attribute("code").Value
                              });
