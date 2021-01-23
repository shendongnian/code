    foreach (var map in subCat.Mappings)
    {
        var attribs = map.Attributes;
        if (attribs != null)
        {
            foreach (var attrib in attribs)
            {
                System.Console.WriteLine("{0}={1}", attrib.Name, attrib.Value);
            }
        }
    }
