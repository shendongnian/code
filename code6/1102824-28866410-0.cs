    private void DoOpenHierarchy(Microsoft.Office.Interop.OneNote.HierarchyScope scope)
    {
        Output = "Open Hierarchy Section...\r\n";
        var strXml = string.Empty;
        var objectId = string.Empty;
        _app.GetHierarchy(null, scope, out strXml);
        try
        {
            var xdoc = XDocument.Parse(strXml);
            var ns = xdoc.Root.Name.Namespace;
            if (scope == Microsoft.Office.Interop.OneNote.HierarchyScope.hsSections)
            {
                var noteBook = xdoc.Root.Descendants(ns + "Notebook").FirstOrDefault();
                if (noteBook != null)
                {
                    var sectionName = "My New Section";
                    Output += string.Format("Attempting to create section '{0}' in {1}...\r\n", sectionName, noteBook.Attribute("name").Value);
                    var location = string.Format("{0}\\{1}.one", noteBook.Attribute("path").Value, sectionName);
                    _app.OpenHierarchy(location, string.Empty, out objectId, Microsoft.Office.Interop.OneNote.CreateFileType.cftSection);
                    Output += string.Format("Section ID Created: {0}\r\n", objectId.ToString());
                }
                else
                {
                    Output += "ERROR: Not able to determine a 'path' in order to store new section.\r\n";
                }
            }
        }
        catch (Exception ex)
        {
            Output += string.Format("{0}:{1}\r\n", ex.GetType(), ex.Message);
        }
        Output += "\r\nOpen Hierarchy Section Done.\r\n";
    }
