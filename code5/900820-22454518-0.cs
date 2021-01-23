    public IEnumerable<database_ab> getData(Query query)
        {
    
            var data = db.database_ab.AsQueryable();
    
            if (query.name != null)
            {
                data = data.Where(c => c.Name == query.name);
            }
    
            if (query.price != null)
            {
                data = data.Where(c => c.Price == query.price);
            }
    
            return data;
        }
