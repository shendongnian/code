    var nodeList = xml.SelectNodes("/");
    Assembly asm = typeof(XmlDocument).Assembly;
    var t = asm.GetType("System.Xml.XPathNodeList");
    var listField = t.GetField("list", BindingFlags.NonPublic | BindingFlags.Instance);
    List<XmlNode> list = (List<XmlNode>)listField.GetValue(nodeList);
    list.Add(...);  // <- the goal!
