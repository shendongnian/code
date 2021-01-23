    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace Serialization_Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyXmlDocument document = new MyXmlDocument();
                document.MyExample.NodeA.value = "Value To Node A";
                document.MyExample.NodeC.value = "Value To Node C";
                document.WriteToXml(@"C:\Users\user_Name\Desktop\mydocument.xml");
            }
        }
    
        [XmlRoot("xmlExample")]
        public class XmlExample
        {
            private NodeA_Elem _nodea;
            [XmlElement()]
            public NodeA_Elem NodeA
            {
                get
                {
                    return _nodea;
                }
                set
                {
                    _nodea = value;
                }
            }
            public bool ShouldSerializeNodeA()
            {
                return !String.IsNullOrEmpty(_nodea.value);
            }
    
            private NodeB_Elem _nodeb;
            [XmlElement("NodeB")]
            public NodeB_Elem NodeB
            {
                get
                {
                    return _nodeb;
                }
                set
                {
                    _nodeb = value;
                }
            }
            public bool ShouldSerializeNodeB()
            {
                return !String.IsNullOrEmpty(_nodeb.value);
            }
            private NodeC_Elem _nodec;
            [XmlElement("NodeC")]
            public NodeC_Elem NodeC
            {
                get
                {
                    return _nodec;
                }
                set
                {
                    _nodec = value;
                }
            }
            public bool ShouldSerializeNodeC()
            {
                return !String.IsNullOrEmpty(_nodec.value);
            }
    
            public XmlExample()
            {
                _nodea = new NodeA_Elem();
                _nodeb = new NodeB_Elem();
                _nodec = new NodeC_Elem();
            }
        }
    
        public class NodeA_Elem
        {
            [XmlText()]
            public string value { get; set; }
        }
    
        public class NodeB_Elem
        {
            [XmlText()]
            public string value { get; set; }
        }
    
        public class NodeC_Elem
        {
            [XmlText()]
            public string value { get; set; }
        }
    
        public class MyXmlDocument
        {
            private XmlExample _myexample;
            public XmlExample MyExample
            {
                get
                {
                    return _myexample;
                }
                set
                {
                    _myexample = value;
                }
            }
    
            public void WriteToXml(string path)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlExample));
    
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.Encoding = Encoding.Unicode;
    
                StringWriter txtwriter = new StringWriter();
                XmlWriter xmlwtr = XmlWriter.Create(txtwriter, settings);
                serializer.Serialize(xmlwtr, MyExample);
    
                StreamWriter writer = new StreamWriter(path);
                writer.Write(txtwriter.ToString());
    
                writer.Close();
            }
    
            public MyXmlDocument()
            {
                _myexample = new XmlExample();
            }
        }
    }
