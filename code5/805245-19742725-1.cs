    void Main()
    {
        {
            var jsonData = @"{""Fields"":[{""MyProp"":""my prop value"",""Prop1"":""prop 1 value""}]}";
            var myApp = JsonConvert.DeserializeObject<MyApplication>(jsonData);
            Console.WriteLine(myApp.Fields[0].MyProp); // "my prop value"
            Console.WriteLine(((Application)myApp).Fields == null); // "True"
        }
        {
            // just to make sure it's not being clever because "MyProp" is specified
            // we'll try this also, which could be deserialized as an Application
            var jsonData = @"{""Fields"":[{""Prop1"":""prop 1 value""}]}";
            var myApp = JsonConvert.DeserializeObject<MyApplication>(jsonData);
            Console.WriteLine(myApp.Fields[0].Prop1); // "prop 1 value"
            Console.WriteLine(((Application)myApp).Fields == null); // "True"
        }
    }
    public class MyApplication : Application
    {
        public new List<MyApplicationField> Fields { get; set; }
    }
    public class Application
    {
        public List<ApplicationField> Fields { get; set; }
    }
    public class MyApplicationField : ApplicationField
    {
        public string MyProp { get; set; }
    }
    public class ApplicationField
    {
        public string Prop1 { get; set; }
    }
