    public class MyClass : DynamicObject
    {
        public IDictionary<string, string> Properties {get; private set;}
        public MyClass(IDictionary<string, string> properties)
        {
            this.Properties = properties;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if(Properties.Keys.Contains(binder.Name))
            {
                result = Properties[binder.Name];
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, string> properties = new Dictionary<string, string>() {
                { "prop1", "value1"}, { "prop2", "value2"} };
            dynamic my = new MyClass(properties);
            System.Console.WriteLine(my.prop1);
        }
    }
