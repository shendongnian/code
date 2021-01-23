    int startYear = 2000;
    int endYear = 2005;
    
    void Main()
    {
    	int totalDays = Convert.ToInt32((new DateTime(endYear, 12, 31) - (new DateTime(startYear, 01, 01))).TotalDays);
    	bool[] days = new bool[totalDays];
    	
    	List<Tuple<DateTime, DateTime>> times = new List<Tuple<DateTime, DateTime>>() {
    		new Tuple<DateTime, DateTime>(new DateTime(2000, 01, 01), new DateTime(2000, 01, 05)),
    		new Tuple<DateTime, DateTime>(new DateTime(2000, 01, 08), new DateTime(2002, 06, 15)),
    		new Tuple<DateTime, DateTime>(new DateTime(2002, 06, 19), new DateTime(2005, 12, 26))
    	};
    	
    	// Go over all blocks and add them to the days array.  This could be bit logic if you really want to save memory
    	foreach(Tuple<DateTime, DateTime> block in times) {
    		int startBlock = GetBlockFromDate(block.Item1);
    		int endBlock = GetBlockFromDate(block.Item2);
    		
    		for(int blockIndex = startBlock; blockIndex < endBlock; blockIndex++) {
    			days[blockIndex] = true;
    		}
    	}
    	
        // this is the actual checking for gaps...  I chose to use a linear approach.
    	for (int dayIndex = 0; dayIndex < days.Length; dayIndex++) {
    		if (!days[dayIndex]) {
    			DateTime missingDate = new DateTime(startYear, 1, 1).AddDays(dayIndex);
    			Console.WriteLine("Missing Day: {0}", missingDate);
    		}
    	}
    }
    
    int GetBlockFromDate(DateTime blockDate) {
    	DateTime startDate = new DateTime(startYear, 1, 1);
    	int blockIndex = Convert.ToInt32((blockDate - startDate).TotalDays);
    	return blockIndex;
    }
