    MyContext _context = new MyContext();
    ObjectContext objContext = ((IObjectContextAdapter)_context).ObjectContext;
    var nameTypes = objContext.MetadataWorkspace.GetItems<EntityType>(DataSpace.OSpace).Select(c => c.FullName).ToList();
    List<Type> types = new List<Type>();
    
    foreach (var name in nameTypes)
    {
        var type = Type.GetType(name);
        types.Add(type);
    }
