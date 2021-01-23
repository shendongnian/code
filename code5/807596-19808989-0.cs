    var dates = new[] 
    	{ 
    		new DateTime(2013, 11, 6, 12, 56, 1),
    		new DateTime(2013, 11, 6, 12, 56, 0),  
    		new DateTime(2013, 11, 6, 12, 56, 50),  
    		new DateTime(2013, 11, 6, 12, 10, 0)  
    	};
    var q = dates.GroupBy(d => d.Ticks / TimeSpan.TicksPerMinute)
           .Select(g => g.First());
