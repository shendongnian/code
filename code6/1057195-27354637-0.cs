    ObjectContext objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
    ObjectSet<YourEntity> set = objectContext.CreateObjectSet<YourEntity>();
    IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                .KeyMembers
                                                .Select(k => k.Name);
