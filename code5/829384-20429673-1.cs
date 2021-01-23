    var result = doc.Descendants("pro")
                    .Select(p => new
                    {
                        Name = p.Attribute("NAME").Value,
                        Type = (string)p.Element("type"),
                        ID = (string)p.Element("ID"),
                        Stas = p.Descendants("sta")
                                .Select(sta => new
                                {
                                    ID = sta.Attribute("ID").Value,
                                    Value = (string)sta
                                }).ToList()
                    })
                    .ToList();
