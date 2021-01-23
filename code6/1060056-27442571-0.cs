    var reader = new StreamReader(File.OpenRead(@path));
    string line1 = reader.ReadLine();
    if (line1.Contains("Server, Tagname, Value, Timestamp, Questionable, Annotated, Substituted"))
    {
	    List<string> listPointValue = new List<string>();
					
	    // Add first line to listPointValue
	   var line = reader.ReadLine();
       var values = line.Split(',');
	   foreach (string value in values)
	   {
		    listPointValue.Add(value);
	   }
							
       while (!reader.EndOfStream)
       {
            // Read next line
            line = reader.ReadLine();
            values = line.Split(',');
		    // If next line is a full line, add the previous line and create a new line
		    if (values.Count() > 1)
            {
			    allValues.Add(listPointValue);
			    listPointValue = new List<string>();
		    }
               
		    // Add values to line
		    foreach (string value in values)
		    {
			     listPointValue.Add(value);
		    }
	    }
        allValues.Add(listPointValue);
    }
