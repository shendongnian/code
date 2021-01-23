    var objectItemCollection = 
       (ObjectItemCollection )((IObjectContextAdapter)ctx)
       .ObjectContext.MetadataWorkspace.GetItemCollection(DataSpace.OSpace);
    foreach(var entityType in objectItemCollection.GetItems<EntityType>())
    {
        Console.WriteLine(objectItemCollection.GetClrType(entityType).FullName);
    }
