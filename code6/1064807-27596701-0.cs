    string[] filelines = File.ReadAllLines(filename);
    if (filelines != null)
    {
    	if (filelines.Length % 4 == 0)
    	{
            // which array element are we getting to at the start of each employee.
    		int arrayBase = 0;
    		for( int i=0; i < (int)(filelines.Length / 4); i++ )
    		{
    			arrayBase = i*4;
    			employee.EmpNum = int.Parse(filelines[arrayBase]);
    			empNames.Name = filelines[arrayBase + 1];
    			empNames.Address = filelines[arrayBase + 2];
    			string[] rateAndHours = filelines[arrayBase + 3].Split(' ');
    			// you would still have to parse the rate and hours though.
    			double justRate = double.Parse(rateAndHours[0]);
    			int justHours = int.Parse(rateAndHours[1]);
    			// obviously add your own try\catch confirmation on parsing issues
    			// and ultimately store in your record entries
    		}
    	}
    }
