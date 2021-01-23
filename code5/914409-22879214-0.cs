    IEnumerable<string> GetReferenceProperies<T>(DbContext context)
    {
        var oc = ((IObjectContextAdapter)context).ObjectContext;
        var entityType = oc.MetadataWorkspace.GetItems(DataSpace.OSpace)
                           .OfType<EntityType>()
                           .FirstOrDefault (et => et.Name == typeof(T).Name);
        if (entityType != null)
        {
            foreach (NavigationProperty np in entityType.NavigationProperties
                    .Where(p => p.ToEndMember.RelationshipMultiplicity
                                         == RelationshipMultiplicity.One
                             || p.ToEndMember.RelationshipMultiplicity
                                         == RelationshipMultiplicity.ZeroOrOne))
            {
                yield return np.Name;
            }
        }
    }
