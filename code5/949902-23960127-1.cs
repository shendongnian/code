        var teams = (from p in results.Descendants("team")
                         select new
                         {
                             Id = utils.GetDecimal((string)p.Attribute("id")),
                             TeamName = (string)p.Element("name"),
                             Players = p.Elements("player")
                             .Select(x => new
                             {
                                 Name = (string)x.Attribute("name"),
                                 Position = (string)x.Attribute("position")
                             })
                             .ToList()
                         }).ToList();
