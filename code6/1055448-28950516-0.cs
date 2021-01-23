    // Get info from OneNote
    string xml;
    onApp.GetHierarchy(null, OneNote.HierarchyScope.hsSections, out xml);
    XDocument doc = XDocument.Parse(xml);
    XNamespace ns = doc.Root.Name.Namespace;
    // Assuming you have a notebook called "Test"
    XElement notebook = doc.Root.Elements(ns + "Notebook").Where(x => x.Attribute("name").Value == "Test").FirstOrDefault();
    if (notebook == null)
    {
        Console.WriteLine("Did not find notebook titled 'Test'.  Aborting.");
        return;
    }
    // If there is a section, just use the first one we encounter
    XElement section;
    if (notebook.Elements(ns + "Section").Any())
    {
        section = notebook.Elements(ns + "Section").FirstOrDefault();
    }
    else
    {
        Console.WriteLine("No sections found.  Aborting");
        return;
    }
    // Create a page
    string newPageID;
    onApp.CreateNewPage(section.Attribute("ID").Value, out newPageID);
    // Create the page element using the ID of the new page OneNote just created
    XElement newPage = new XElement(ns + "Page");
    newPage.SetAttributeValue("ID", newPageID);
    // Add a title just for grins
    newPage.Add(new XElement(ns + "Title",
        new XElement(ns + "OE",
            new XElement(ns + "T",
                new XCData("Test Page")))));
    // Add an outline and text content
    newPage.Add(new XElement(ns + "Outline",
        new XElement(ns + "OEChildren",
            new XElement(ns + "OE",
                new XElement(ns + "T",
                    new XCData("Here is some new sample text."))))));
    // Now update the page content
    onApp.UpdatePageContent(newPage.ToString());
