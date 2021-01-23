    void Main()
    {
        var derivedType = typeof(Derived);
        derivedType.GetProperties().Dump("All");
        derivedType.GetProperties(BindingFlags.DeclaredOnly
            | BindingFlags.Public | BindingFlags.Instance).Dump("Declared only");
    }
    
    public class Base
    {
        public string BaseProperty { get; set; }
    }
    
    public class Derived : Base
    {
        public string DerivedProperty { get; set; }
    }
