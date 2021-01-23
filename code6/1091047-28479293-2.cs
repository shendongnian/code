    dctCurrency = doc.Root.Descendants("Currency")
                          .Select(c => new
                          {
                             Key = c.Attribute("name").Value,
                             Value = c.Elements("symbol").Select(x => x.Value).ToList()
                          })
                          .ToDictionary(k => k.Key, v => v.Value);
