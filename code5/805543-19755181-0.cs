        private void search ()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("xml path");
            XmlNode node = doc.SelectSingleNode("/Root");
            string name = "Dewi Anggraini";
            string id = "001";
            foreach (XmlNode nodes in node.SelectNodes("UNIT_VISIT"))
            {
                if (nodes != null && nodes["NAME"].InnerText == name && nodes["ID_UNIT"].InnerText == id)
                {
                    // do stuff here
                }
            }
        }
