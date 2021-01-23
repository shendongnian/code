    public string ReplaceInXML(string xml, string nodeToUpdate, string newValue)
    {
      // Load xml into a format we can do LINQ to XML on
      XElement root = XElement.Load((new StringReader(xml)), LoadOptions.None);
    
      // Look for all descendants where the node matches the one we want and update all the values to what we want
      // E.g. Get Node "productDetail" -> and set its value to newValue.
      root.Descendants().Where(i => i.Name.LocalName == nodeToUpdate)
    	.ToList()
    	.ForEach(i => i.ReplaceNodes(newValue));
    
      return root.ToString();
    }
