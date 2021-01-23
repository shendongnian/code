    XmlDocument doc = new XmlDocument();
    doc.Load(@"C:\Path\To\Xml\File.xml");
    
    var rootNode = doc.DocumentElement;
    
    XmlNodeList ps = rootNode.SelectNodes("//p");
    for (int i = 0; i < ps.Count; i++)
    {
         if (ps[i].SelectNodes("//pr").Count == 0)
         {
             rootNode.RemoveChild(ps[i]);
         }
    }
