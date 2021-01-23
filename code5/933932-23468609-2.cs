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
        [XmlElement("attributes")]
        public Attributes Attributes { get; set; }
    }
    [XmlRoot(ElementName = "attributes")]
    public class Attributes
    {
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("displayed")]
        public string Displayed { get; set; }
        [XmlElement("selected")]
        public string Selected { get; set; }
        [XmlArray("items")]
        [XmlArrayItem("item", typeof(string))]
        public List<string> Items { get; set; }
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
                           <type>Integer</type>
                           <displayed>4</displayed>
                           <selected>0</selected>
                           <items>
                           <item>5</item>
                           <item>10</item>
                           <item>20</item>
                           <item>50</item>
                           </items>
                           </attributes>
                           </component >
                           </parameter>";
            XmlSerializer deserializer = new XmlSerializer(typeof(Parameter));
            XmlReader reader = XmlReader.Create(new StringReader(xmlstring));
            Parameter parameter = (Parameter)deserializer.Deserialize(reader);
            Console.WriteLine("Type: {0}", parameter.Component.Attributes.Type);
            Console.WriteLine("Displayed: {0}", parameter.Component.Attributes.Displayed);
            Console.WriteLine("Selected: {0}", parameter.Component.Attributes.Selected);
            Console.WriteLine("Items: ");
            foreach (var item in parameter.Component.Attributes.Items)
            {
                Console.WriteLine("\t{0}", item);
            }
            Console.ReadLine();
        }
    }
