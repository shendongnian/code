    // Assuming the xml looks like the sample you provided
    public static XElement ToXml(this string text)
    {
    	var xml = XElement.Parse(text);
    	// grab the first parent
    	var parent = xml.Descendants("elements").FirstOrDefault();
    	// grab the Value nodes
    	var nodes = xml.Descendants("Value").Where (x => x.Parent != xml && x.Parent != parent);
    	// add the Value nodes to the first elements node
    	parent.Add(nodes.ToArray());
    	// remove all the branches the Value elements came from
    	nodes.ToList()
    		  .ForEach(x=> x.Ancestors()
    			.TakeWhile(a=> a != xml)
    			.Where (a => a != parent)
    			.Remove());
    	return xml;
    }
    
