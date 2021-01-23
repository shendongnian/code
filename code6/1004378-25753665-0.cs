    class MyPersistentClass : Persistent
    {
        public string Text { get; set; }
    }
    // Create the index. Must be non-unique to support duplicate keys
    dbRoot.MyIndex = db.CreateIndex<string, MyPersistentClass>(IndexType.NonUnique);
    // Put the data
    dbRoot.MyIndex.Put("my string", new MyPersistentClass { Text="some value" });
    dbRoot.MyIndex.Put("my string", new MyPersistentClass { Text="another value" });
 
    // query the index to get multiple values. The range from and till values are the same
    MyPersistentClass[] values = dbRoot.MyIndex.Get("my string", "my string");
    // process the first occurrence
    if (values.Length > 0)
    {
       DoProcess(values[0]);
    }
