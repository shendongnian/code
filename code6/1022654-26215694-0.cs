    var buildings = xmlDoc.Descendants("building")
                          .Select(be => new Building (
                              (string)be.Element("name"),
                              (int)be.Element("buildTime"),
                              (int)be.Element("treeCost"),
                              (int)be.Element("stoneCost"),
                              (int)be.Element("goldCost")))
                          .ToList();
