    IEnumerable<NavigationProperty> GetNavigationProperies<T>(DbContext context,
                                                              T entity = default(T))
        where T : class
    {
        var oc = ((IObjectContextAdapter)context).ObjectContext;
        var entityType = oc.MetadataWorkspace
                           .GetItems(DataSpace.OSpace).OfType<EntityType>()
                           .FirstOrDefault (et => et.Name == typeof(T).Name);
        return entityType != null
            ? entityType.NavigationProperties
            : Enumerable.Empty<NavigationProperty>();
    }
