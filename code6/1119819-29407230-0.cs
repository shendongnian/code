    var loadedRenders = _db.Renders.Include(r => r.Images)
                        .Include(m => m.DisplayFormats)
						...
                        .Include(m => m.EventTypes)
                        .AsQueryable(); // AsQueryable does not execute the query to sql as ToList would
						
	if (Request.QueryString["attr1"] != "")
	{
		// Where() will return IQueryable and the query will not be executed yet
		loadedRenders = loadedRenders.Where(<apply filtering here for attr1>);
	}
						
	if (Request.QueryString["attr2"] != "")
	{
		loadedRenders = loadedRenders.Where(<apply filtering here for attr2>);
	}
	
    // This will then create sql with all the applied filters
	var concreteList = loadedRenders.ToList();
	
