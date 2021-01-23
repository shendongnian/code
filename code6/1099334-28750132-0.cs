    List<XElement> repeatedNodes = new List<XElement>();
    for(XElement node in xml.Descendants())
    {
          if(node.Parent.Elements(node.Name).Count() > 1))
          {
               repeatedNodes.Add(node);
          }
     }
