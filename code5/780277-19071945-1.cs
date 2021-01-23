    var xDoc = XDocument.Load(fname);
    var list = xDoc.Descendants(ns + "Cube")
                    .Where(cube => cube.Attributes().Any(a => a.Name == "currency"))
                    .Select(cube => new
                    {
                        Currency = cube.Attribute("currency").Value,
                        Rate = (decimal)cube.Attribute("rate")
                    })
                    .ToList();
