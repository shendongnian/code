    private Run ParseForOpenXML(string textualData)
    {
    	Run run = new Run();
    	
    	//split string on paragraph breaks, and create a Break object for each
    	string[] newLineArray = { Environment.NewLine, "\n" };
    	string[] textArray = textualData.Split(newLineArray, StringSplitOptions.None);
    	bool first = true;
       
    	foreach (string line in textArray)
    	{
    		if (!first)
    		{
    			run.Append(new Break());
    		}
    		first = false;
    
    		//split string on tab breaks, and create a new TabChar object for each
    		bool tFirst = true;
    		string[] tabArray = line.Split('\t');
    		foreach(string fragment in tabArray)
    		{
    			if (!tFirst)
    			{
    				run.Append(new TabChar());
    			}
    			tFirst = false;
    
    			Text txt = new Text();
    			txt.Text = fragment;
    			run.Append(txt);
    		}
    	}
    
    	return run;
    }
