    var queryable = this.Collection.AsQueryable().Where(x => x.FirstName = "FirstName" && x => x.LastName= "LastName");
    
    if (!includeAge)
    {
    	return queryable;
    }
    
    return queryable.Where(x => x.Age == 21);
