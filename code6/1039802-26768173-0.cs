    public class MyClass
    {
        public ServiceType? ServiceType { get; set; }
        public ShouldSerializeServiceType() { return ServiceType.HasValue; }
    }
