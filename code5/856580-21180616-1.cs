    Set(x => x.States, c =>
    { 
        c.Lazy(CollectionLazy.Lazy); // or CollectionLazy.NoLazy, CollectionLazy.Extra
    
        c.Table("tableName");
        c.Schema("schemaName");
        c.BatchSize(100);
        ...
