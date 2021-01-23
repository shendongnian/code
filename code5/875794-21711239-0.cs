    var items = oc.MetadataWorkspace.GetItems(DataSpace.SSpace).OfType<EntityType>();
    foreach (var entityType in items)
    {
        var props = string.Join(",", entityType.Properties
                    .Where(x => x.IsStoreGeneratedIdentity));
        Trace.WriteLine(string.Format("{0}: {1}", entityType.Name, props));
    }
