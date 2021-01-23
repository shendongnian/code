    XmlDocument doc2 = new XmlDocument();
    doc2.Load(Server.MapPath("names.xml")); 
    XmlNode ageNode = doc2.SelectSingleNode(string.Format("//PERSONES/person/age[text() = '{0}']", age));
    if (ageNode != null)
    {
        var personNode = ageNode.ParentNode;
    
        doc2.DocumentElement.RemoveChild(personNode);
        doc2.Save(Server.MapPath("names.xml"));
    
    }
