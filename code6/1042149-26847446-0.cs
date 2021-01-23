    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    
    namespace DemoApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(@"
                    <Prop Name='StartTime' Type='Number' Flags='0x0'>
                    <Value>171.8032865</Value>
                    </Prop>");
    
                XmlElement element = doc.DocumentElement;
                XmlNode valueNode = element.ChildNodes[0];
    
                double value = double.Parse(valueNode.InnerText);
    
                Console.ReadLine();
            }
        }
    }
