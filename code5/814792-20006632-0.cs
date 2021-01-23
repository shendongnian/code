        XDocument xDoc = XDocument.Load(@"bpmn.xml");
        var ns = XNamespace.Get("http://www.omg.org/spec/BPMN/20100524/MODEL");
        //Run query
        foreach(XElement level1Element in xDoc.Root.Elements(ns + "process"))
        {
            System.Diagnostics.Debug.WriteLine(level1Element.Attribute("id").Value);
    
            foreach(XElement level2Element in level1Element.Elements(ns + "task"))
            {
                System.Diagnostics.Debug.WriteLine("  " + level2Element.Attribute("name").Value);
            }
        }
