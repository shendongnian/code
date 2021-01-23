       var adapter = (IObjectContextAdapter)db;
       var objectContext = adapter.ObjectContext;
       var objectSet = objectContext.CreateObjectSet<SomeEntity>();
       var entitySet = objectSet.EntitySet;
       var keyNames = entitySet.ElementType.KeyMembers
                     .Where(p => p.MetadataProperties.Any(m => m.PropertyKind == PropertyKind.Extended
                                      && Convert.ToString(m.Value) == "Identity"))
                     .Select(e => e.Name).ToList();
