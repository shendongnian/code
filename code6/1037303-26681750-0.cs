    public Dictionary<string, T> MigrateXMLtoObject<T>(
        string xmlPath, MyLibrary oLibrary, Func<MyLibrary, XmlNode, T> factory)
    {
        Dictionary<string, T> oDictionary = new Dictionary<string, T>();
        XML_File_Reader oDoc = new XML_File_Reader(xmlPath);
        if (oDoc.IsDocumentValid)
        {
            XmlNodeList oList = oDoc.GetList("Row");
            if (oList.Count != 0)
                foreach (XmlNode xn in oList)
                {
                    XmlNode oThisNode = xn;
                    T thisItem = factory(oLibrary, oThisNode);
                    // It's not really clear to me what you wanted to do
                    // here. If the object constructor is handling applying
                    // the node data to the object, you shouldn't need to
                    // "migrate" more, right? And the dictionary seems to
                    // want to add the object as the value, with the key
                    // being some text. Where do you get the key?
                    //oDoc.MigrateXMLtoObject(T, oThisNode);
                    oDictionary.Add(objectKey, thisItem);
                }
        }
        oDoc = null;
        return oDictionary;
    }
