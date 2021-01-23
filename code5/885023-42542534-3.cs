    ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext; 
    ObjectSet<TEntity> set = objectContext.CreateObjectSet<TEntity>(); 
    IEnumerable<string> keyNames = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name); 
    
    var keyName = keyNames.FirstOrDefault(); 
    var keyType = typeof(TEntity).GetProperty(keyName).PropertyType
    foreach (var entry in updatedSet
                    .Select(obj =>
                        Convert.ChangeType(obj.GetType()
                                              .GetProperty(keyName)
                                              .GetValue(obj, null), keyType))
                    .Select(value => context.Set<TEntity>().Find(value)))
                {
                    values.Add(entry);
                }
