        private void AddCData(string path) {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.DocumentElement;
            foreach (XmlNode childNode in root.SelectNodes("/rootNode/category/string")) {
                AddCData(childNode);
            }
            doc.Save(path + "_output.xml");
        }
	
        private void AddCData(XmlNode node) {
            string innerText = node.InnerText;
            if (!string.IsNullOrEmpty(innerText)) {
                if (!innerText.StartsWith("<![CDATA[")) {
                    var newCDATA = node.OwnerDocument.CreateCDataSection(innerText);
                    node.InnerText = "";
                    node.AppendChild(newCDATA);
                }
            }
        }
