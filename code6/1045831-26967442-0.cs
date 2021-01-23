        [XmlRoot("Exclusionpolicys")]
        public class ExclusionPolicys
        {
            [XmlElement("Exclusionpolicy")]
            public List<Exclusionpolicy> Exclusionpolicy;
        }
    
        public class Exclusionpolicy
        {
                
            [XmlElement("ValuationRoute")]
            public ExcludedPolicyValuationRoute ValuationRoutes { get; set; }
            [XmlElement("ExcludeHive")]
            public ExcludedPolicyHives ExcludedHives { get; set; }
        }
    
        public class ExcludedPolicyHives
        {
            public List<string> Hives { get; set; }
        }
    
        public class ExcludedPolicyValuationRoute
        {
            public List<string> ValuationRoutes { get; set; }
        }
