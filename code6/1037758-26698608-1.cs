    public class MyClass : DynamicObject
    {
        public IDictionary<string, object> Properties { get; private set; }
        public MyClass(IDictionary<string, object> properties)
        {
            this.Properties = properties;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return Properties.TryGetValue(binder.Name, out result);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>() {
                { "prop1", "value1"}, { "prop2", "value2"} };
            dynamic my = new MyClass(properties);
            System.Console.WriteLine(my.prop1);
        }
    }
