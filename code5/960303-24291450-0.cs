    if (File.Exists(strRootPropertyFile))
    {
    	string[] lines = null;
    	try
    	{
    		lines = File.ReadAllLines(strRootPropertyFile).ToList();
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    
    	if (lines != null)
    	{
    		for(int i = 0; i < lines.Length; i++)
    			if (lines[i].StartWith("UserID="))
    				lines[i] += "|TEST ONLY";				
    				
    		File.WriteAllText(strRootPropertyFile, string.Join(Environment.NewLine, lines));
    	}
    }
