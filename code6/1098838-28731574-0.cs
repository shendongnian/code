    using System.IO;
    
    public static string[][] CSV_ToArray(string path, string separator = ";")
    {
        // check if the file exists
    	if (!File.Exists(path))
    		throw new FileNotFoundException("The CSV specified was not found.");
    		
        // temporary list to store information
    	List<string[]> temp = new List<string[]>();
    	
        using (var reader = new StreamReader(File.OpenRead(path)))
    	{
    		while (!reader.EndOfStream)
    		{
    			// read the line
    			string line = reader.ReadLine();
    			// if you need to give some changes on the inforation
                // do it here!
    			string[] values = line.Split(separator.ToCharArray());
    			
                // add to the temporary list
    			temp.Add(values);			
    		}
    	}
    	
        // convert te list to array, which it will be a string[][]
    	return temp.ToArray();	
    }
