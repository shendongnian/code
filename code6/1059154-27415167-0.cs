    XDocument xml = XDocument.Load(stream);
    var legalNames = xml.Root
                        .Elements("Demographics")
                        .Elements("Names")
                        .Elements("LegalName");
    foreach(XElement ln in legalNames)
    {
        string firstName = (string)ln.Element("FirstName");
        // or you can get (string)ln.Element("FirstName").Element("Part");
        string lastName = (string)ln.Element("LastName");
        string otherName = (string)ln.Element("OtherName");
    }
