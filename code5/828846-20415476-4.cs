    // Load XML file as an IEnumerable. This allows you to query it.
    var xmlDoc = XDocument.Load(file)
    	.Elements("pro")
        .Select(pro => new
    			{
    				Name = pro.Attribute("NAME").Value,
    				Scode = pro.Elements("scode").Select(scode => new
    				{
    					ID = scode.Attribute("ID").Value,
    					Val = scode.Value
    				})
    			});
    
    // loop through each <pro> element			
    foreach (var pro in xmlDoc)
    {
    	// Get Pro Name
    	Console.WriteLine(pro.Name);
    	
        // loop through each <scode> element inside <pro>
    	foreach(var scode in pro.Scode)
    	{
    		// Get Scode ID:
    		Console.WriteLine(scode.ID);
    		
    		// Get Scode Value:
    		Console.WriteLine(scode.Val);
    	}
    }
