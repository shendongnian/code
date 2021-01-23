    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    [XmlRoot("element")]
    public class MyElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlElement("subelement1")]
        public string Value { get; set; }
    
    }
    public static class Program
    {
        static void Main()
        {
            var xml = @"
    <element name=""1"">
        <subelement1>2</subelement1>
    </element>
    <element name=""2"">
        <subelement1>3</subelement1>
    </element>";
            var ser = new XmlSerializer(typeof(MyElement));
            using (var sr = new StringReader(xml))
            using (var xr = XmlReader.Create(sr, new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                ConformanceLevel = System.Xml.ConformanceLevel.Fragment
            }))
            {
                while (xr.MoveToContent() == XmlNodeType.Element)
                {
                    using (var subtree = xr.ReadSubtree())
                    {
                        var obj = (MyElement)ser.Deserialize(subtree);
                        Console.WriteLine("{0}: {1}",
                            obj.Name, obj.Value);
                    }
                    xr.Read();
                }
            }
        }
    
    }
