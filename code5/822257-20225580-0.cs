    doc
    	.Element("Vehicles")
    	.ReplaceAll
    	(
    		doc
    			.Element("Vehicles")
    			.Elements("Truck")
    			.OrderBy(i => i.Attribute("name").Value)
    			.Union
    			(
    				new []
    				{
    					new XElement
    					(
    						"Cars", 
    						doc
    							.Element("Vehicles")
    							.Element("Cars")
    							.Elements()
    							.OrderBy(i => i.Attribute("name").Value).ToArray()
    					)
    				}
    			)	
    	);
