    MyContext _context = new MyContext();
    ObjectContext objContext = ((IObjectContextAdapter)_context).ObjectContext;
    var nameTypes = objContext.MetadataWorkspace.GetItems<EntityType>(DataSpace.OSpace);
    List<Type> types = new List<Type>();
    
    foreach (var entityType in nameTypes)
    {
        var type = Type.GetType(entityType.FullName + "," + Assembly.GetExecutingAssembly().FullName);
        types.Add(type);
    }
