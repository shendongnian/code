	// Create file a single time
	using (TextWriter writer = File.CreateText(path)) 
	{
		for (int i = 0; i < iterations; i++)
		{
			// Add content to the file inside the loop
			writer.Write(LastName.Trim());
            //etc...
		}	    
	}
