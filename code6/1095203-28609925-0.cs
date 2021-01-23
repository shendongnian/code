    [AttributeUsage(AttributeTargets.Property)]
    public class MyCustomAttribute : Attribute 
    {
        public void DoSomething(Type t) 
        {
        }
    }
    public class Dec 
    {
        [MyCustomAttribute]
        public string Bar { get; set; }
    }
    // Start of usage example
    Type type = typeof(Dec);
    var attributes = type.GetCustomAttributes(true);
    var myCustomAttributes = attributes.OfType<MyCustomAttribute>();
    foreach (MyCustomAttribute attr in myCustomAttributes) 
    {
        attr.DoSomething(type);
    }
