        [XmlRoot("Exclusionpolicys")]
        public class ExclusionPolicys
        {
            [XmlElement("Exclusionpolicy")]
            public List<Exclusionpolicy> Exclusionpolicy;
        }
    
        public class Exclusionpolicy
        {
                
            [XmlElement("ValuationRoutes")]
            public List<ExcludedPolicyValuationRoutes> ValuationRoutes { get; set; }
            [XmlElement("ExcludeHives")]
            public List<ExcludedPolicyHives> ExcludedHives { get; set; }
        }
    
        public class ExcludedPolicyHives
        {
            [XmlElement("ExcludeHive")]
            public List<ExcludedPolicyHive> ExcludedPolicyHive;
        }
    
        public class ExcludedPolicyValuationRoutes
        {
            [XmlElement("ValuationRoute")]
            public List<ValuationRoute> ValuationRoute { get; set; }
        }
        public class ExcludedPolicyHives
        {
            public string Hives { get; set; }
        }
    
        public class ExcludedPolicyValuationRoute
        {
            public string ValuationRoutes { get; set; }
        }
