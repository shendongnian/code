    var context = new YourDbContext();
    var adapter = (IObjectContextAdapter)context;
    var objectContext = adapter.ObjectContext;
    ...
    
    public bool IsModified()
    {
        bool modified = 
        context.ObjectStateManager.GetObjectStateEntries(~EntityState.Unchanged);
                                   .Any();
        return modified;
    }
