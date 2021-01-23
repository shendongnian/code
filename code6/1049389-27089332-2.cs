        private XDocument DeleteID(string XmlFile, string NodeID)
        {
            XDocument list = XDocument.Load(XmlFile);
            list.Descendants().Where(elm => (string)elm.Attribute("id") == NodeID).Remove();
            return list;
        }
