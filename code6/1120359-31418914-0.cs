    var notebookName = "My Notebook";
    var sectionName = "My Meetings";
    var xdoc = XDocument.Parse(strXML2);
    var ns = xdoc.Root.Name.Namespace;
    var myNotebook = xdoc.Root.Descendants(ns + "Notebook").SingleOrDefault(n => n.Attribute("name").Value == notebookName);
    if (myNotebook != null)
    {
        var mySection = myNotebook.Descendants(ns + "Section").SingleOrDefault(s => s.Attribute("name").Value == sectionName);
        if (mySection != null)
        {
            var pages = mySection.Descendants(ns + "Page");
            // Now do something here with the pages!
            // ...
        }
    }
