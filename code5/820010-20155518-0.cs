    var xDoc = XDocument.Load("Input.xml");
    var items = xDoc.Root
                    .Element("Chapter")
                    .Elements("Verse")
                    .Select(v => new
                    {
                        Id = (int)v.Attribute("VerseID"),
                        Content = (string)v
                    }).ToList();
