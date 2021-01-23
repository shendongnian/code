    // load document
    var xDoc = XDocument.Load("Input.txt");
    // prepare XNamespace instance
    var saml = XNamespace.Get("urn:oasis:names:tc:SAML:2.0:assertion");
    // query for items and put them into Dictionary<string, XElement>
    var attributes = xDoc.Root.Element(saml + "Assertion")
                              .Element(saml + "AttributeStatement")
                              .Elements(saml + "Attribute")
                              .ToDictionary(x => (string)x.Attribute("Name"), x => x.Element(saml + "AttributeValue"));
    // update XElement values using created Dictionary
    attributes["UserID"].Value = "New UserID";
    attributes["UserFirstName"].Value = "New UserName";
    attributes["UserLastName"].Value = "New UserLastName";
    attributes["ReasonForSearch"].Value = "New ReasonForSearch";
    // save updated document back
    xDoc.Save("Input.txt");
