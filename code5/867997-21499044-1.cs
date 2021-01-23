    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;
    
    namespace ConsoleApplication60
    {
        class Program
        {
            static void Main(string[] args)
            {
                XslCompiledTransform proc = new XslCompiledTransform();
                proc.Load("../../XSLTFile1.xslt");
    
                XsltArgumentList xsltArgs = new XsltArgumentList();
                xsltArgs.AddExtensionObject("http://example.com/mf", new Test1());
    
                proc.Transform("../../XMLFile1.xml", xsltArgs, Console.Out);
            }
        }
    
        public class Test1
        {
            public XPathNodeIterator GetNodeSet()
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("root");
                foreach (string s in new string[] { "foo", "bar", "kibo" })
                {
                    XmlElement t = doc.CreateElement("t");
                    t.InnerText = s;
                    root.AppendChild(t);
                }
                return root.CreateNavigator().SelectChildren(XPathNodeType.Element);
            }
        }
    }
