    public IEnumerable<Tuple<string, string, string, string>> GetTableAndColumns<TEntity>()
    {
        var entityContainerMappings = (this as IObjectContextAdapter).ObjectContext
            .MetadataWorkspace.GetItems(DataSpace.CSSpace)
            .OfType<EntityContainerMapping>();
        var entityTypeMappings = entityContainerMappings
            .SelectMany(m => m.EntitySetMappings
                .Where(esm => esm.EntitySet.ElementType.Name == typeof(TEntity).Name))
            .SelectMany(esm => esm.EntityTypeMappings).ToArray();
        var propertyMappings = (from etm in entityTypeMappings
            from prop in etm.EntityType.Properties
            join pm in entityTypeMappings.SelectMany(etm => etm.Fragments)
                .SelectMany(mf => mf.PropertyMappings)
                .OfType<ScalarPropertyMapping>()
                on prop.Name equals pm.Property.Name
            select new {etm, prop, pm}
            );
        return propertyMappings.Select(x => Tuple.Create(x.etm.EntitySetMapping.EntitySet.Name, x.pm.Column.Name, x.prop.DeclaringType.Name, x.prop.Name));
    }
