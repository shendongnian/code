    List<Chapters> List = (from d in doc.Root.Element("array").Elements("dict")
                           select new HighwayCode
                           {
                               Title = (string)d.Element("string"),
                               SubTitles = String.Join(",", d.Element("array")
                                                             .Elements("dict")
                                                             .Elements("string")
                                                             .Select(s => (string)s))
                           }).ToList();
