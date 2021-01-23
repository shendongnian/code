    using System.Configuration;
    
    namespace ExtendedKVP
    {
        public class RuleSection : ConfigurationSection
        {       
            public const string SectionName = "RuleSet";
    
            private const string RuleCollectionName = "TheRules";
    
            [ConfigurationProperty(RuleCollectionName)]
            [ConfigurationCollection(typeof(RuleCollection), AddItemName = "add")]
            public RuleCollection ConnectionManagerEndpoints { get { return (RuleCollection)base[RuleCollectionName]; } }
        }
    
        public class RuleCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new RuleElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((RuleElement)element).RuleId;
            }
        }
    
        public class RuleElement : ConfigurationElement
        {
            [ConfigurationProperty("ruleId", IsRequired = true)]
            public string RuleId
            {
                get { return (string)this["ruleId"]; }
                set { this["ruleId"] = value; }
            }
    
            [ConfigurationProperty("ruleDesc", IsRequired = true)]
            public string RuleDesc
            {
                get { return (string)this["ruleDesc"]; }
                set { this["ruleDesc"] = value; }
            }
    
            [ConfigurationProperty("ruleActive", IsRequired = false, DefaultValue = false)]
            public bool RuleActive
            {
                get { return (bool)this["ruleActive"]; }
                set { this["ruleActive"] = value; }
            }       
        }
    }
