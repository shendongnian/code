    //to get this to work in Linq to XML, need to terminate the R nodes
    var xml = XDocument.Parse(@"<A>
    	<B id = ""1"">
    		<R/>
    		<C id=""ABC"" />
    	</B>
    	<B id = ""2"" >
    		<R/>
    		<C id=""ABC"" />
    	</B>
    	<B id = ""3"" >
    		<R/>
    		<C id=""XYZ"" />
    	</B>
        <B id = ""4"">
            <R/>
            <C id=""XYZ"" />
        </B>
        <B id = ""5"">
            <R/>
            <C id=""QWE"" />
        </B>
     </A>");
     
     
     Dictionary<string, XElement> previousCElements = new Dictionary<string, XElement>();
     XElement currentC, previousC;
     
     foreach(var node in xml.Descendants("B"))
     {
     	if (!previousCElements.ContainsKey(node.Name.LocalName))
    	{
    		previousCElements[node.Name.LocalName] = node.Element("C");
    	}
    	else
    	{
    		previousC = previousCElements[node.Name.LocalName];
    		currentC = node.Element("C");
    		if (previousC.Attribute("id").Value.Equals(currentC.Attribute("id").Value, StringComparison.InvariantCultureIgnoreCase))
    		{
    			currentC.Remove();
    		}
    		previousCElements.Remove(node.Name.LocalName);
    	}
     }
 
