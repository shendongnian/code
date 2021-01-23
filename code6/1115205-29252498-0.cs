    namespace TestApp
    {
        using System;
        using System.IO;
        using System.Xml.Schema;
        using System.Xml.Serialization;
    
        class Program
        {
            static void Main(string[] args)
            {
                var list = new List
                {
                    Map = new[]
                    {
                        new Entry {EntryItem = new EntryItem {Key = "1", Value = "ASD"}},
                        new Entry {EntryItem = new EntryItem {Key = "2", Value = "DFE"}}
                    }
                };
    
                Console.Write(Serialize(list));
                Console.ReadKey();
            }
    
            private static string Serialize(List list)
            {
                var xmlSerializer = new XmlSerializer(typeof (List));
                var stringWriter = new StringWriter();
                xmlSerializer.Serialize(stringWriter, list);
                return stringWriter.ToString();
            }
        }
    
        [XmlRoot(ElementName = "Root")]
        public partial class List
        {
            [XmlArray(ElementName = "List")]
            [XmlArrayItem("Map", typeof (Entry), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
            public Entry[] Map { get; set; }
        }
    
        public class Entry
        {
            [XmlElement("Entry")]
            public EntryItem EntryItem { get; set; }
        }
    
        public class EntryItem
        {
            [XmlAttribute]
            public string Key { get; set; }
    
            [XmlAttribute]
            public string Value { get; set; }
        }
    }
