    public async Task<IEnumerable<Category>> Get(ODataQueryOptions<Category> options)
    {
         var myQueryable = (IQueryable<Category>)options.ApplyTo(context.Categories);	
    	 return await myQueryable.ToListAsync();
    }
