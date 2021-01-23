    MyContext _context = new MyContext();
    ObjectContext objContext = ((IObjectContextAdapter)_context).ObjectContext;
    EntityContainer container = objContext.MetadataWorkspace.GetEntityContainer(objContext.DefaultContainerName, DataSpace.CSpace);
    List<EntityType> nameTypes = container.BaseEntitySets.OfType<EntitySet>().Select(c => c.ElementType).ToList();
    List<Type> types = new List<Type>();
    
    foreach (var entityType in nameTypes)
    {
        //.GetType return null
        var type = Type.GetType(entityType.FullName + "," + Assembly.GetExecutingAssembly().FullName);
        types.Add(type);
    }
