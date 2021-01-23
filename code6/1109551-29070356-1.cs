    class Schema
    {
        public int Id { get; set; }
        public string SchemeName { get; set; }
        public string RelationshipRule { get; set; }
        public int RelationshipPriority { get; set; }
    }
    class ParentSchema : Schema
    {
        public IEnumerable<ChildSchema> Children { get; set; }
    }
    class ChildSchema : Schema
    {
        public IEnumerable<ParentSchema> Parents { get; set; }
    }
