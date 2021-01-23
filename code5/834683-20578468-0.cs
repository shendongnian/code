    private static IQueryable<Db.Category> FilterContains(string searchFor, string excludedBrFields, IQueryable<Db.Category> categories)
    {
    	if (searchFor.StartsWith("*") && searchFor.EndsWith("*"))
    	{
    		searchFor = searchFor.Substring(1, searchFor.Length - 2);
    	}
    	searchFor = searchFor.ToLower();
    
    	var predicate = PredicateBuilder.False<Db.Category>();
    	if (!excludedBrFields.Contains("Title"))
    	{
    		predicate = predicate.Or(x => x.Title.ToLower().Contains(searchFor));
    	}
    
    	if (!excludedBrFields.Contains("Description"))
    	{
    		predicate = predicate.Or(x => x.Description != null && x.Description.ToLower().Contains(searchFor));
    	}
    	
    	if (!excludedBrFields.Contains("Comments"))
    	{
    		predicate = predicate.Or(x => x.Comments != null && x.Comments.ToLower().Contains(searchFor));
    	}
    	return categories.Where(predicate.Compile()).AsQueryable();
    }
