    var modes = XDocument.Load(fname)
                .Descendants("Mode")
                .Select(m => new
                {
                    Name = m.Attribute("Name").Value,
                    ClassTypes = m.Elements().ToDictionary(e=>e.Name.LocalName,e=>e.Value)
                })
                .ToList();
