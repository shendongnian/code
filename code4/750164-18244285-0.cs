    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static string xml_to_deserialize = @"
        <layout_cell type=""attribute"">
            <attribute_and_presentation attribute=""Name"" /> 
            <layout_group is_column=""true"" label_column_width=""100"" /> 
        </layout_cell>
    ";
            static void Main(string[] args)
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(layout_cell));
                //test desieralization
                using (var stringReader = new StringReader(xml_to_deserialize))
                using (var reader = System.Xml.XmlReader.Create(stringReader))
                {
                    var result = serializer.Deserialize(reader);
                    result.ToString(); //breakpoint here to examimne
                }
                //test serialization
                var toSerialize = new layout_cell()
                {
                    type = "some type",
                    attribute_and_presentation = new attribute_and_presentation()
                    {
                        attribute = "some attribute"
                    },
                    layout_group = new layout_group()
                    {
                        is_column = "true",
                        label_column_width = "100"
                    }
                };
                using (var writer = new System.IO.StringWriter())
                {
                    serializer.Serialize(writer, toSerialize);
                    Console.WriteLine(writer.ToString());
                }
                Console.WriteLine("done, hit enter.");
                Console.ReadLine();
            
            }
        }
        [System.Serializable()]
        public class layout_cell
        {
            [XmlAttribute("type")]
            public string type;
            [XmlElement("attribute_and_presentation")]
            public attribute_and_presentation attribute_and_presentation;
            [XmlElement("layout_group")]
            public layout_group layout_group;
        }
    
        [System.Serializable()] public class attribute_and_presentation
        {
            [XmlAttribute]
            public string attribute;
        }
        [System.Serializable()] public class layout_group
        {
            [XmlAttribute("is_column")] public string is_column;
            [XmlAttribute("label_column_width")] public string label_column_width;
        }
    }
