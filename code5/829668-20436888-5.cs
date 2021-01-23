    var players = doc.Descendants("player")
                     .Where(r => r.Element("name").Value.StartsWith("David"))
                     .OrderByDescending(r => int.Parse(r.Element("goals").Value))
                     .Select(r => new
                      {
                          Name = r.Element("name").Value + "   ",
                          Goal = r.Element("goals").Value + "    ",
                      })
                     .Take(3);
