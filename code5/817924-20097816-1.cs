    // Update entities in original list
    foreach (var d in _testDtos)
    {
    	foreach (var e in _testEntities)
    	{
    		if (e.PrimaryKey == d.PrimaryKey)
    		{
    			Mapper.Map(d, e);
    		}
    	}
    }
