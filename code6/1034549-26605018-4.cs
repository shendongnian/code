    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Xsl;
    
    namespace ConsoleApplication73
    {
        class Program
        {
            static void Main(string[] args)
            {
                XslCompiledTransform myXslTrans = new XslCompiledTransform();
                myXslTrans.Load(
                        XmlReader.Create("../../XSLTFile1.xslt", new XmlReaderSettings()
                        {
                            DtdProcessing = DtdProcessing.Parse
                        }),
                        new XsltSettings(true,false),
                        null
                        );
    
                myXslTrans.Transform("../../XMLFile1.xml", null, Console.Out);
            }
        }
    }
