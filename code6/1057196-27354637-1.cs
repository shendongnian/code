    ObjectContext objectContext = ((IObjectContextAdapter)_db).ObjectContext;
    ObjectSet<YourEntity> set = objectContext.CreateObjectSet<YourEntity>();
    IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                .KeyMembers
                                                .Select(k => k.Name);
