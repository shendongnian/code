    public static void updateXmlNodeWithAttribute(string XmlNodeName, string XmlAttributeName, List<string> XmlNodeAttribute, List<string> XmlNodeValue)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(_connection);
            XmlNodeList xnode = getXmlNodeList(XmlNodeName,xdoc);
            for (int i = 0; i < XmlNodeAttribute.Count; i++)
            {
                foreach (XmlNode item in xnode)
                {
                    if (item.Attributes[XmlAttributeName].Value == XmlNodeAttribute[i].ToString())
                    {
                        item.InnerText = XmlNodeValue[i].ToString();
                    }
                }
            }
            xdoc.Save(_connection);
        }
        public static XmlNodeList getXmlNodeList(string XmlNodeName, XmlDocument doc)
        {
            XmlNodeList elemList = doc.GetElementsByTagName(XmlNodeName);
            return elemList;
        }
