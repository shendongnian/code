    XmlDocument xmlDoc = new XmlDocument();
    serializer.Serialize(ms, obj);
    ms.Position = 0;
    xmlDoc.Load(ms);
    XmlElement newElem = xmlDoc.CreateElement("Response");
    //wrong: works for only 1 child element
    //kept for edit/reference
    //foreach (XmlNode item in xmlDoc.DocumentElement.ChildNodes)
    //{
    //    newElem.AppendChild(item);
    //}
    while (xmlDoc.DocumentElement.ChildNodes.Count != 0)
    {
        newElem.AppendChild(xmlDoc.DocumentElement.ChildNodes[0]);
    }
    xmlDoc.DocumentElement.AppendChild(newElem);
