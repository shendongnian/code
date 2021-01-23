    var doc = new XmlDocument();
    .....
    //select all elements having non empty inner text
    var nodesHavingInnerText = doc.DocumentElement
    							  .SelectNodes("//*[normalize-space(text())]");
    var result = "";
    foreach (XmlNode node in nodesHavingInnerText)
    {
    	    	//put "-" repeated as many as current node's level in the XML doc
    	result += string.Concat(Enumerable.Repeat("-", GetLevel(node))) 
    					+ 
    			  node.InnerText 
    					+ 
    			  Environment.NewLine;
    }
