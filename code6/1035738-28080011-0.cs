	ODataModelBuilder builder = new ODataConventionModelBuilder();
	builder.EntitySet<TestEntity>("TestEntities");
	
	builder.Namespace = "NS";
	    
	builder.EntityType<TestEntity>()
			.Action("TestAction")
	    .CollectionParameter<string>("ArrayHere");    
