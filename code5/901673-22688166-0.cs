    try
    {
    	//Read the file
    	System.IO.StreamReader f = new System.IO.StreamReader(fileName, System.Text.Encoding.UTF8);
    	string line = f.ReadLine();
    	
    	//Split text by comma
    	string[] tokens = line.Split(',');
    	int tokenCount = tokens.Length;
    
    	//Reconstruct the broken strings - tokensList retreives the final values
    	System.Collections.ArrayList tokensList = new System.Collections.ArrayList();
    	
    	string token = "";
    	bool stringFound = false;
    	string currentToken;
    	for (int i=0; i<tokenCount; i++)
    	{
    		currentToken = tokens[i];
    		if (!stringFound)
    		{	
    			//Check if not a string
    			if ((currentToken.Trim().StartsWith("\"") && !currentToken.Trim().EndsWith("\"")) || currentToken.Trim().Equals("\""))
    			{
    				stringFound = true;
    				token = currentToken;
    			}
    			else
    			{
    				//Add the string as final value
    				tokensList.Add(currentToken);
    			}
    		}
    		else
    		{
    			//Reconstruct the string
    			token += "," + currentToken;
    			if (currentToken.Trim().EndsWith("\""))
    			{
    				int quoteIndex = currentToken.LastIndexOf("\"");
    				if (quoteIndex == 0 || (quoteIndex > 0 && currentToken[quoteIndex-1] != '"'))
    				{
    					tokensList.Add(token);
    					stringFound = false;
    					token = "";
    				}
    			}
    		}
    	}
    	
    }
    catch (Exception ex)
    {
    	Console.WriteLine(ex.StackTrace);
    }
