    Check the Example below
       // Create a DOM document with some content.
       XmlDocument doc = new XmlDocument();
       XmlElement child = doc.CreateElement("Child");
       child.InnerText = "child contents";
       XmlElement root = doc.CreateElement("Root");
       root.AppendChild(child);
       doc.AppendChild(root);
    
       // Create a reader and move to the content.
       using (XmlNodeReader nodeReader = new XmlNodeReader(doc)) {
       // the reader must be in the Interactive state in order to
       // Create a LINQ to XML tree from it.
       nodeReader.MoveToContent();
    
       XElement xRoot = XElement.Load(nodeReader);
       Console.WriteLine(xRoot);
    }
