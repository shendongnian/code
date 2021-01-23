      XDocument doc = XDocument.Load(@"C:\temp\test.xml");
        var ns = doc.Root.GetDefaultNamespace();
      var elements = doc.Element(ns + "Root").Element(ns + "Parents").Elements(ns + "Parent").Elements().Where(w => w.Value == "John");
      foreach (var element in elements)
      {
        element.Value = "Wayne";
      }
        var stream = new FileStream(@"C:\temp\test.xml", FileMode.Create);
      doc.Save(stream);
