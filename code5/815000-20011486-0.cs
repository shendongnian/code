    [AttributeUsage(AttributeTargets.Class)]
    public class NameAttribute : Attribute
    {
        public NameAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
    [Name("Foo")]
    public class SomeClass
    {
    }
