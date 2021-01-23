    public class EntityKeyValue
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }
    public class EntityKey
    {
        public string EntitySetName { get; set; }
        public string EntityContainerName { get; set; }
        public List<EntityKeyValue> EntityKeyValues { get; set; }
        public bool IsTemporary { get; set; }
    }
    public class RootObject
    {
        public int OrderID { get; set; }
       [ScriptIgnore]
        public int EmployeeID { get; set; }
        public string CustomerID { get; set; }
       [ScriptIgnore]
        public int EntityState { get; set; }
        [ScriptIgnore]
        public EntityKey EntityKey { get; set; }
    }
