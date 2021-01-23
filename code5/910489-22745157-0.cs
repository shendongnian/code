    public SdsAbstractObject GetAttachedToContext()
    {
        var ObjContext = (SdsDbContext.Current as IObjectContextAdapter).ObjectContext;
        var ExistingItem = ObjContext.GetObjectByKey(GetEntityKey()) as SdsAbstractObject;    
        if (ExistingItem != null)
            return ExistingItem;
        else
        {
            DbSet.Attach(this);
            return this;
        }
    } 
    public EntityKey GetEntityKey()
    {
        string DbSetName = "";
        foreach (var Prop in typeof(SdsDbContext).GetProperties())
        {
            if (Prop.PropertyType.IsGenericType
                && Prop.PropertyType.GenericTypeArguments[0] == ObjectContext.GetObjectType(GetType()))
                DbSetName = Prop.Name;
        }
        if (String.IsNullOrWhiteSpace(DbSetName))
            return null;
        else
            return new EntityKey("SdsDbContext." + DbSetName, "Id", Id);
    }
