    using(ObjectContext context = new ObjectContext())  
    {
    var queryResult = from meta in context.MetadataWorkspace.GetItems(DataSpace.CSpace)
                      .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                      from p in (meta as EntityType).Properties
                      .Where(p => p.DeclaringType.Name == context.GetType().Name
                      && p.Name == PropertyName
                      Select new {Length = p.TypeUsage.Facets["MaxLength"].Value, Name=p.TypeUsage.Facets["Name"].Value, p.TypeUsage.Facets["FacetType"].Value 
    }
