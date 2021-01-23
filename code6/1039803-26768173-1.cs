    public class MyClass
    {
        public ServiceType? ServiceType { get; set; }
        public bool ShouldSerializeServiceType() { return ServiceType.HasValue; }
    }
