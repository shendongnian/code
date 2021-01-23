    doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                                            new XElement("Root"));
    doc.Root.Add(new XElement("IMEI", "ABCD"));
    doc.Root.Add(new XElement("Manufacturer", "Nokia"));
    doc.Root.Add(new XElement("Model", "Lumia 525"));
    var contactsElement = new XElement("Item",
    									new XElement("Name", "Contact"),
    									new XElement("Size",
    										new XElement("Value", "123"),
    										new XElement("Type", "KB")),
    								    new XElement("MD5", "78sd8f6sd6fsdf8sdbs5f78svbfsd576s"),
    								    new XElement("Desc", "Contact File"));
    var mainNode = new XElement("Items", new XElement(contactsElement));
    doc.Root.Add(mainNode);
