                ObjectContext objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
                ObjectSet<Entity> set = objectContext.CreateObjectSet<Entity>();
                IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                            .KeyMembers
                                                            .Select(k => k.Name);
                string keyName = keyNames.FirstOrDefault();
