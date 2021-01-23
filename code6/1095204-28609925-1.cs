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
    // Shorter (no need for the first var attributes line): 
    // var myCustomAttributes = Attribute.GetCustomAttributes(type, typeof(MyCustomAttribute), true);
    foreach (MyCustomAttribute attr in myCustomAttributes) 
    {
        attr.DoSomething(type);
    }
