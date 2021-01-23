     XDocument xDoc = XDocument.Load(@"xmlfile1.xml");
      //Run query
      XNamespace ns = "http://www.omg.org/spec/BPMN/20100524/MODEL";
      foreach (XElement level1Element in xDoc.Descendants(ns + "process"))
      {
        System.Diagnostics.Debug.WriteLine(level1Element.Attribute("id").Value);
        foreach (XElement level2Element in level1Element.Elements(ns + "task"))
        {
          System.Diagnostics.Debug.WriteLine(
              "  " + level2Element.Attribute("name").Value);
        }
      }
