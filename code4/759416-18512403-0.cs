    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Xml;
    public class Test
    {
        public static void Main()
        {
            var json = @"{""page"":  {""mode"": ""2"", ""ref"": ""user""}}";
            var xmlDocument = new XmlDocument();
            var d=  xmlDocument.CreateXmlDeclaration("1.0","utf-8","yes");
            xmlDocument.AppendChild(d);
            var xml = JsonConvert.DeserializeXmlNode(json);
            var root = xmlDocument.ImportNode(xml.DocumentElement,true);
            xmlDocument.AppendChild(root);
            Console.WriteLine(xmlDocument.OuterXml);
        }
    }
