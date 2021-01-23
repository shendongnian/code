    public class TypeDocumentation
    {
        public TypeDocumentation()
        {
            PropertyDocumentation = new Collection<PropertyDocumentation>();
        }
        public string Summary { get; set; }
        public ICollection<PropertyDocumentation> PropertyDocumentation { get; set; } 
    }
    public class PropertyDocumentation
    {
        public PropertyDocumentation(string name, string type, string docs)
        {
            Name = name;
            Type = type;
            Documentation = docs;
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Documentation { get; set; }
    }
