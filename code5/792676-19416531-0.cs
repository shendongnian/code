    Dictionary<string, msg> masterDictionary = new Dictionary<string, mgs>();
    foreach (string file in filePath)
    {
        XDocument xdoc = XDocument.Load(file);
        Dictionary<string, msg> fileDictionary = xdoc
            .Descendants("msg")
            .ToDictionary(m => m.Element("msgId").Value,
                          m => new msg
                               {
                                   msgId = m.Element("msgId").Value,
                                   msgType = m.Element("msgType").Value,
                                   name = m.Element("name").Value
                               });
        //now insert your new values into the master
        foreach(var newValue in fileDictionary)
            masterDictionary.Add(newValue.Key, newValue.Value);
    }
