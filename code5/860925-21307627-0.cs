    string[] ReadAllLinesFromBookmark(string fileName, ref long lastPosition)
    {
    	using (var fs = File.OpenRead(fileName))
    	{
    		fs.Position = lastPosition;
    		
    		using  (var sr = new StreamReader(fs))
    		{
    			string line = null;
    			
    			List<string> lines = new List<string>();
    			
    			while ((line = sr.ReadLine()) != null)
    			{
    				lines.Add(line);
    			}
    			
    			lastPosition = fs.Position;
    			
    			return lines.ToArray();
    		}
    	}
    }
