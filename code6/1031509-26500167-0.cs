    public IQueryable ConditionalAttribute(IQueryable query, Filter filter)
    { 
        if(filter.FirstName != "") {
            query = query.Where(x => x.First_Name == filter.FirstName);
        }
        return query;
    }
