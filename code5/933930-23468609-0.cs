    [XmlRoot(ElementName = "parameter")]
    public class Parameter
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("label")]
        public string Label { get; set; }
        [XmlElement("unit")]
        public string Unit { get; set; }
        [XmlElement("component")]
        public Component Component { get; set; }
    }
    [XmlRoot(ElementName = "component")]
    public class Component {
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlArray("attributes")]
        [XmlArrayItem("item", typeof(string))]
        public List<string> Attributes { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string xmlstring = @"<?xml version='1.0' encoding='utf-8' ?> 
                           <parameter>  
                           <name>max_amount</name>
                           <label>Max Amount</label>
                           <unit>Millions</unit>
                           <component>
                           <type>Combo</type>
                           <attributes>
                           <item>5</item>
                           <item>10</item>
                           <item>20</item>
                           <item>50</item>
                           </attributes>
                           </component >
                           </parameter>";
            XmlSerializer deserializer = new XmlSerializer(typeof(Parameter));
            XmlReader reader = XmlReader.Create(new StringReader(xmlstring));
            Parameter parameter = (Parameter)deserializer.Deserialize(reader);
            foreach (var item in parameter.Component.Attributes)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
