            try
            {
    			Hashtable htKeys = new Hashtable();
    			List<string> sqlToExecute = new List<string>();			
    			
                IEnumerable<string> lines = File.ReadLines("path-to-your-file.sql");
    			foreach (string line in lines)
    			{
    				// parse out key field here
    				string keyfield = RegExToFindYourValue(line);
    				
    				if (!htKeys.ContainsKey(keyfield)) 
    				{
    					sqlToExecute.Add(line);				
    					htKeys.Add(keyfield, line);
    				}
                    else
                    {
                      // duplicate key, handle here.
                    }
    			}
    				
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
