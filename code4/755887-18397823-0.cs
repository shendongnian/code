    public static class XmlNodeExtension
    {
        public static bool TryGetNodeInnerText(this XmlNode node, string xPath, out string innerText)
        {
            Debug.Assert(!string.IsNullOrEmpty(xPath));
            innerText = null;
            if (node == null)
                return false;
            var selectedNode = node.SelectSingleNode(xPath);
            if (selectedNode == null)
                return false;
            innerText = selectedNode.InnerText;
            return true;
        }
    }
    string fees;
    if (!node.TryGetNodeInnerText("fees", out fees))
    {
         // log error or any handling
    }
