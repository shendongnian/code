    var xdoc = XDocument.Load(path_to_xml); // load xml file
    var ns = xdoc.Root.GetDefaultNamespace();
    // create new Compile element
    var compile = new XElement(ns + "Compile", 
                       new XAttribute("Include" ,"Program2.cs"));
    // add it to last ItemGroup element
    xdoc.Root.Elements(ns + "ItemGroup").Last().Add(compile); 
    // remove another Compile element
    xdoc.Root.Elements(ns + "ItemGroup")
        .SelectMany(ig => ig.Elements(ns + "Compile"))
        .Where(c => (string)c.Attribute("Include") == "clsBlubb.cs")
        .Remove();
    xdoc.Save(path_to_xml); // save changes back to file
