    public class MyClientObject
    {
        [Description("The name")]
        public string Name {get;set;}
        [Description("The client object type")]
        [ApiAllowableValues2("MyEnum", typeof(MyEnum))]
        public MyEnum MyEnum { get; set; }
    }
