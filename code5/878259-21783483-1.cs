    class MyClass
    {
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
    }
    var json = JsonConvert.SerializeObject(new MyClass(), 
                    Formatting.Indented, 
                    new JsonSerializerSettings { ContractResolver = new MyContractResolver() });
