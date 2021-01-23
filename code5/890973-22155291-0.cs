    var xDoc = XDocument.Load(path);
    var employees = (from e in xDoc.Root.Elements("employee")
                     let projects = e.Element("projects")
                                     .Elements("projectID")
                                     .Select(p => (int)p)
                                     .ToList()
                     let id = (string)e.Element("id")
                     select new Employee(id, projects)).ToList();
