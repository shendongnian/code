    // you have 4 families from DB, API or anywhere.
    var failies = new List<Family>
    {
    	new Family { Id = 1, ParentId = 1, Name = "foo", Birthday = new DateTime(1971, 1, 1) },
    	new Family { Id = 1, ParentId = 1, Name = "bar", Birthday = new DateTime(1982, 1, 1) },
    	new Family { Id = 1, ParentId = 1, Name = "foobar", Birthday = new DateTime(1993, 1, 1) },
    	new Family { Id = 1, ParentId = 1, Name = "fake", Birthday = new DateTime(2000, 1, 1) },
    };
    
    // make predicate!
    // if a family's Birthday is before than 1980 'or' Name contains "ke".
    var predicate = PredicateBuilder.True<Family>();
    predicate = predicate.And(o => o.Birthday < new DateTime(1980, 1, 1));
    predicate = predicate.Or(o => o.Name.Contains("ke"));
    
    // you should make IQueryable in order to use PredicateBuilder.
    var result = failies.AsQueryable()
    	.Where(predicate)
    	.Select(o => new
    	{
    		o.Id, o.Name, o.Birthday	// only project what you want.
    	})
    	.ToList();
    
    // now, result should contains "foo" and "fake".
    foreach (var family in result)
    {
    	Debug.WriteLine("Name: " + family.Name);
    }
