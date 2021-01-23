    class ScheduleDateProvider
    {
    	private static readonly Dictionary<string, Func<DateTime, DateTime>> modesDict;
    	
    	static ScheduleDateProvider()
    	{
    		// Register modes 
    		modesDict = new Dictionary<string, Func<DateTime, DateTime>>();
    		modesDict.Add("Quaterly", (dt) => dt.AddMonths(3) );
    		modesDict.Add("Monthly", (dt) => dt.AddMonths(1) );
    		modesDict.Add("Weekly", (dt) => dt.AddDays(7) );
    		modesDict.Add("Daily", (dt) => dt.AddDays(1) );
    	}
    	
    	public IEnumerable<DateTime> GetDatesInRange(DateTime startDate, DateTime endDate, string mode)
    	{
    		// Assemble dates in a list
    		var getNextDateFct = modesDict[mode];
    		var lst = new List<DateTime>();
    		while(startDate < endDate)
    		{
    			lst.Add(startDate);
    			startDate = getNextDateFct(startDate);
    		}
    		return lst.AsReadOnly();
    	}
    }
