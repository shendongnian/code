    using (var dbcontext = new ExampleEntities())
    {
        var query = dbcontext.People.AsQueryable();
        if(includeMetadata)
        {
            query = query.Include("metadata");
        }
        if(includeInteractions) 
        {
            query = query.Include("interactions");
        }    
    }
