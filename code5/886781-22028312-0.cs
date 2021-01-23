         var  dates = new Dictionary<DateTime, double>(){
    	
    		{DateTime.Parse("2014-05-01"), -0.15},
    		{DateTime.Parse("2014-04-1"), 1.8},
    		{DateTime.Parse("2014-03-31"), 10},
    		{DateTime.Parse("2014-03-30"), 10}
    	};
    	
    	var uniqueDates = new Dictionary<DateTime, double>(new DateEqualityComparer());
    	foreach(var item in dates) {		
    		DateTime key = new DateTime(item.Key.Year, item.Key.Month, 1);		
    		uniqueDates[key] = item.Value;
    		
    	}
    class DateEqualityComparer : IEqualityComparer<DateTime>
    {
    
        public bool Equals(DateTime  value1, DateTime value2)
        {
             if (value1.Month == value2.Month && value1.Year == value2.Year) return true;
    		 
    		 return false;
        }
    	
    	public int GetHashCode(DateTime value)
        {
           
            int hash = value.Month ^ value.Year;
            return hash.GetHashCode();
        }
    }
