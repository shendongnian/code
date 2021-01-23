    public IList<MyEntity> PerformQuery(
    	ISession session,
    	int pageSize,
    	int? lastElementId)
    {
    	var query = session.QueryOver<MyEntity>();
    	
    	if (lastElementId.HasValue)
    	{
    		query.Where(
    			Restrictions.GtProperty(
    				Projections.Property<MyEntity>(e => e.Name),
    				Projections.SubQuery(
    					QueryOver.Of<MyEntity>()
    						.Where(le => le.Id == lastElementId.Value)
    						.Select(le => le.Name))));
    				
    	}
    	
    	return query.OrderBy(e => e.Name).Asc
    		.Take(pageSize)		
    		.List<MyEntity>();
    }
	
