    public class TransportViewModel  
    {
        public List<WheelProperty> WheelPropertyList {get;set;}
        ...
    }
    public class WheelProperty
    {
        public TransportViewModel TransportView {get;set;}
        public string PropertyA {get;set;}
        public string PropertyB {get;set;}
        ...
    }
