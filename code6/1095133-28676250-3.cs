    var resolver = new DynamicContractResolver<MyClass>(
        mc => mc.MyIntegerProperty,
        mc => mc.MyBoolProperty);
    
    var myClass = new MyClass
    {
        MyIntegerProperty = 4,
        MyStringProperty = "HELLO",
        MyBoolProperty = true
    };
    
    var settings = new JsonSerializerSettings
    {
        ContractResolver = resolver,
        Formatting = Newtonsoft.Json.Formatting.Indented
    };
    
    string serialized = JsonConvert.SerializeObject(
        myClass, settings);
    
    Console.WriteLine(serialized);
