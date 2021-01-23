    static void Main() {
        XmlDocument doc = new XmlDocument();
        doc.Load("test.xml");
        ReadNode(doc.GetElementsByTagName("object")[0]);
        Console.ReadLine();
    }
    static void ReadNode(XmlNode node) {
            //Do something with each Node
            if(node.Attributes.Count > 0) {
                foreach(XmlAttribute attr in node.Attributes) {
                    //Do Something with each Attribute
                }
            }
            if(node.HasChildNodes == true) {
                foreach(XmlNode chlnode in node.ChildNodes) {
                    ReadNode(chlnode);
                }
            }
        }
