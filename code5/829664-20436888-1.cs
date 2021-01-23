    var players = doc.Descendants("player")
                     .OrderByDescending(r => int.Parse(r.Element("goals").Value))
                     .Select(r => new
                      {
                          Name = r.Element("name").Value + "   ",
                          Goal = r.Element("goals").Value + "    ",
                      })
                     .Take(3);
