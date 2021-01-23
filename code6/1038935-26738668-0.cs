    class Converter
    {
        public XmlDocument Convert(XmlDocument inputDocument)
        {
            XmlDocument result = new XmlDocument();
            ConvertNode(inputDocument.DocumentElement, result.DocumentElement, result);
            return result;
        }
        public void ConvertNode(XmlNode inputNode, XmlNode outputNode, XmlDocument outputDoc)
        {
            XmlNode newNode = null;
            // check elemment class
            string htmlClass;
            try { htmlClass = inputNode.Attributes["class"].Value; }
            catch { htmlClass = ""; }
            if(!string.IsNullOrWhiteSpace(htmlClass))
            {
                if (htmlClass.Contains("menuItem"))
                {
                    newNode = outputDoc.CreateElement("MenuItem");
                    outputNode.AppendChild(newNode);
                }
                /// check other wanted nodes etc..
            }
            if (newNode != null)
            {
                foreach (XmlNode node in inputNode.ChildNodes)
                {
                    ConvertNode(node, newNode, outputDoc);
                }
            }
        }
    }
