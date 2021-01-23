    class Schema
    {
        public int Id { get; set; }
        public string SchemeName { get; set; }
        public string RelationshipRule { get; set; }
        public int RelationshipPriority { get; set; }
    }
    class ParentSchema : Schema
    {
        public IEnumerable<Schema> Children { get; set; }
    }
    class ChildSchema : Schema
    {
        public IEnumerable<Schema> Parents { get; set; }
    }
