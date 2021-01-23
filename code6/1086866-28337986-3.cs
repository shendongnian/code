    using System;
    using System.Configuration;
    using System.Xml;
    
    namespace ConfigReader
    {
        class Program
        {
            static void Main(string[] args)
            {
                SomeConfigSection configSection = ConfigurationManager.GetSection("SomeConfig") as SomeConfigSection;
    
                if (configSection != null)
                    Console.WriteLine("Value={0}", configSection.SomeParam.Value);    
            }
        }
        public class SomeConfigSection : ConfigurationSection
        {
            [ConfigurationProperty("SomeParam")]
            public SomeParamElement SomeParam
            {
                get { return this["SomeParam"] as SomeParamElement; }
                set { this["SomeParam"] = value; }
            }
        }
    
        public class SomeParamElement:ConfigurationElement
        {
            protected override void DeserializeElement(XmlReader reader, bool s)
            {
                Value = reader.ReadElementContentAs(typeof(string), null) as string;
            }
            public string Value { get; private set; }
        }
    }
