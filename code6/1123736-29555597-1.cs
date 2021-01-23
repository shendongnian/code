    var tableName = "someTable";
    var oc = ((IObjectContextAdapter)context).ObjectContext;
    
    var items = oc.MetadataWorkspace.GetItems(DataSpace.SSpace).OfType<EntityType>();
    foreach (var entityType in items.Where(e => e.Name == tableName))
    {
    	var props = string.Join(",", entityType.Properties.Where(p => p.Nullable));
    	Debug.WriteLine(string.Format("{0}: {1}", entityType.Name, props));
    }
