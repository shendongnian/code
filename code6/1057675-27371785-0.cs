    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = DummyData();
    
                //DeleteNodes("child1", data);
                DeleteNodes2("child1", data);
    
                Console.ReadLine();
            }
    
            static void DeleteNodes(string node, string xml)
            {
                var values = new HashSet<string>();
                var xmlDocument = XDocument.Parse(xml);
    
                foreach (var n in xmlDocument.Root.Elements(node).ToList())
                {
                    if (!values.Add((string)node))
                        n.Remove();
                }
            }
    
            static void DeleteNodes2(string node, string xml)
            {
                var xmlDocument = XDocument.Parse(xml);
    
                xmlDocument.Root
                         .Elements(node).GroupBy(g => g).SelectMany(f => f).Reverse().Skip(1).Remove();
    
                var duplicates = xmlDocument.Root
                         .Elements(node).GroupBy(g => g).ToList(); 
    
            }
    
            static string DummyData()
            {
                Random r = new Random();
                TextWriter w = new StringWriter();
    
    
                var writer = new XmlTextWriter(w);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("root");
    
                for (int i = 0; i < 200000; i++)
                {
                    int rand = r.Next(3);
                    writer.WriteStartElement(string.Format("child{0}", rand.ToString()));
                    writer.WriteEndElement();
                }
    
                writer.WriteEndElement();
    
                return w.ToString();
            }
        }
    }
