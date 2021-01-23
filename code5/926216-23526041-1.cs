    public class MyClientObject
    {
        [Description("The name")]
        public string Name {get;set;}
        [Description("The client object type")]
        [ApiAllowableValues("ControllerType", "Value One", "Value Two", "Value Three")]
        public MyEnum MyEnum { get; set; }
    }
