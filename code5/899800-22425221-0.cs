        public class NonUsAsciiEncoding : ASCIIEncoding
        {
            public override string WebName
            {
                get
                {
                    return "ascii";
                }
            }
        }
        private void CreateXml()
        {       
            XmlTextWriter xmlwriter = new XmlTextWriter("c:\\test.xml", new NonUsAsciiEncoding());        
            
            XDocument xdoc = new XDocument(
              new XElement("Test")
            );
            xdoc.Save(xmlwriter);
            xmlwriter.Close();
        }
