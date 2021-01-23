    var sides = xdoc.Descendants("Side")
                    .Select(s => new Side {
                        Id = (int)s.Attribute("id"),
                        Option = (int)s.Attribute("option"),
                        StartPrice = (decimal)s.Attribute("startPrice")
                     }).ToList();
