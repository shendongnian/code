    var xdoc = XDocument.Load(path_to_xml);
    var ns = xdoc.Root.GetDefaultNamespace();
    var query = from u in xdoc.Root.Elements(ns + "DetailedUtility")
                select new
                {
                    UtilityId = (int)u.Attribute("UtilityId"),
                    TotalPopulation = u.Elements(ns + "City")
                                       .Sum(c => (int)c.Attribute("Population"))
                };
