    var builder = new ODataConventionModelBuilder();
    
     builder.Namespace = "NS";
    
     builder.EntitySet<TestEntity>("TestEntities");
    
     builder.EntityType<TestEntity>().Collection
        .Function("TestFunction")
        .ReturnsCollectionFromEntitySet<TestEntity>("TestEntities")
        .CollectionParameter<int>("ArrayHere");
