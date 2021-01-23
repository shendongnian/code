    public class MyDynamicObject : DynamicThirdPartyObject
    { }
    
    public class TypedModel
    {
        public string text { get; set; }
    
        public int number { get; set; }
    
        public List<SomeOtherModel> ListOtherModel { get; set; }
    }
