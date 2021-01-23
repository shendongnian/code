    Set(x => x.Users, c =>
    {
        c.Fetch(CollectionFetchMode.Join); // or CollectionFetchMode.Select,
                                           //    CollectionFetchMode.Subselect
        c.BatchSize(100);
        c.Lazy(CollectionLazy.Lazy); // or CollectionLazy.NoLazy, CollectionLazy.Extra
    
        c.Table("tableName");
        c.Schema("schemaName");
        c.Catalog("catalogName");
    
        c.Cascade(Cascade.All);
        c.Inverse(true);
    
        c.Where("SQL command");
        c.Filter("filterName", f => f.Condition("condition"));
        c.OrderBy(x => x.Name); // or SQL expression
                   
        c.Access(Accessor.Field);
        c.Sort<CustomComparer>();
        c.Type<CustomType>();
        c.Persister<CustomPersister>();
        c.OptimisticLock(true);
        c.Mutable(true);
