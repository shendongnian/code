    var items = 
    	purchases.AsEnumerable()
    	.Where(e => e.Field<DateTime>("time") >= lastMinute)
    	.GroupBy( g => g.Id )
    	.Select( f => new  
    	{
    		Id = f.Key,
    		MaxedCount = f.Coun()
    	}
    	.OrderByDecending( i => i.MaxedCount)
    	.Take(3)
