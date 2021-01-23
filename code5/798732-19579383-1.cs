    using System;
    using System.IO;
    using System.Xml.Serialization;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlSerializer ser = new XmlSerializer(typeof(Entry));
                Entry o;
                using (Stream s = File.OpenRead(@"D:\...\representing-a-repeated-pair-of-xml-elements-in-xsd-2.xml"))
                {
                    o = (Entry)ser.Deserialize(s);
                }
                using (Stream s = File.OpenWrite(@"D:\...\representing-a-repeated-pair-of-xml-elements-in-xsd-3.xml"))
                {
                    ser.Serialize(s, o);
                }
            }
        }
    }
