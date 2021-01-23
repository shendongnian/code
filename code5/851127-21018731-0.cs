    var xdoc = XDocument.Load(path_to_xml);
    var query = from u in xdoc.Root.Elements("DetailedUtility")
                select new
                {
                    UtilityId = (int)u.Attribute("UtilityId"),
                    TotalPopulation = u.Elements("City")
                                       .Sum(c => (int)c.Attribute("Population"))
                };
