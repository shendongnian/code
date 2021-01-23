    XmlDocument xmlDocSOR = new XmlDocument();
    XmlDocSOR.Load("filename.xml");
    XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDocSOR.NameTable);
    namespaceManager.AddNamespace("rs", "urn:oasis:names:tc:ebxml-regrep:registry:xsd:2.1");
    namespaceManager.AddNamespace("ns", "urn:oasis:names:tc:ebxml-regrep:rim:xsd:2.1");
    var query = "/rs:SubmitObjectsRequest/ns:LeafRegistryObjectList/ns:ExtrinsicObject/ns:Slot";
    XmlNodeList nodeList = xmlDocSOR.SelectNodes(query, namespaceManager);
                 
    foreach (XmlNode plainnode in nodeList)
    {
        if (plainnode.Attributes["name"].Value == "sourcePatientId")
        {
            XmlNode childnode = plainnode.LastChild;
            XmlElement ee1 = (XmlElement)childnode.FirstChild;
            ee1.InnerText = sPatientID;                      
         }
     }
     xmlDocSOR.Save("filename.xml");
