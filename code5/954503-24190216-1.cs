    // load original XML from the stream
    XDocument loadedData = XDocument.Load(stream);
    // create a new parent XML structure (new root) and load the original nodes
    var newXml = new XDocument(new XElement("Histories"));
    newXml.Root.Add(loadedData.Root);
    // create the new node
    var contactsElement = new XElement("item", 
                                  new XElement("name", "blalllllaaaallaala")));
    NewNode.Add(contactsElement);  
    // add the new node
    newXml.Root.Add(NewNode);
    // save the stream
    newXml.Save(stream);
