    public class PropertyContainer {
    
        public Property property {get; set; }//Could be set to DerivedProperty
    
    }
    [KnownType(typeof(DerivedProperty))]
    public class Property {
        public int BasePropertyData {get; set;}
    }
    public class DerivedProperty : Property {
        public int DerivedPropertyData {get; set; }    
    }
