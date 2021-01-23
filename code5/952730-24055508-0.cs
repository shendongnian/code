    public IQueryable<Person> FilterList(string forename, List<Sorting> sorting) {
        IQueryable<Person> query = dc.Set<Person>();
        if(!string.IsNullOrEmpty(forename)){
            query = query.Where(w=>w.Forename.Contains(forename));
    
    	var orderedQuery = query.OrderBy(x => 1);
    	
        foreach(var sort in sorting) {
            switch(sort.By) {
                case "asc":
                   switch(sort.Sort) {
                       case "forename":
                           orderedQuery = orderedQuery.ThenBy(o=>o.Forename);
                       break;
                       case "surname":
                           orderedQuery = orderedQuery.ThenBy(o=>o.Surname);
                       break;
                   }
                break;
                case "desc":
                   switch(sort.Sort) {
                       case "forename":
                           orderedQuery = orderedQuery.ThenByDescending(o=>o.Forename);
                       break;
                       case "surname":
                           orderedQuery = orderedQuery.ThenByDescending(o=>o.Surname);
                       break;
                   }
                break;
            }
        }
    	
        return orderedQuery;
    }
