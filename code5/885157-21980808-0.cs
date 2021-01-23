    XDocument doc = XDocument.Load("input.xml");// plist file name
    var chapters = (from d in doc.Root.Element("array").Elements("dict")
                    select new Chapter
                    {
                        Title = (string)d.Element("string"),
                        SubTitles = d.Element("array")
                                     .Elements("dict")
                                     .Elements("string")
                                     .Select(s => (string)s)
                                     .ToList()
                    }).ToList();
