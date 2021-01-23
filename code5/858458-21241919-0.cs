    XmlDocument xDoc = new XmlDocument();
    xDoc.Load(@"D:\Map.xml");
            parseXML(xDoc);
    private void parseXML(XmlDocument xdoc) {
            try {
                var enumXMLnode = from xelement in xdoc.GetElementsByTagName("tileset").Cast<XmlElement>()
                                  select xelement;
                foreach (XmlElement innerData in enumXMLnode) {
                    MessageBox.Show(innerData.InnerXml);
                }
            }
            catch { 
            
            }
        }
