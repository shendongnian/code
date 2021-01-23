    public class Patient
    {
        public int PatientId { get; set; }
        // Some properties
        // Complex property
        public MyComplexType Complex { get; set; }
    }
    
    [ComplexType]
    public class MyComplexType
    {
        public SomeType Property1 { get; set; }
        public SomeOtherType Property2 { get; set; }
    }
    
    public class SomeType
    {
        // primitive  properties here
    }
    public class SomeOtherType 
    {
        // primitive  properties here
    }
