    private static object GetXmlPath(XmlNode node) {
      if (node.NodeType == XmlNodeType.Attribute) {
         return String.Format("{0}@{1}={2}", GetXmlPath(((XmlAttribute)node).OwnerElement), node.Name, node.Value);
      }
      return node.ParentNode == null ? "/" : String.Format("{0}{1}/", GetXmlPath(node.ParentNode), node.Name);
    }
