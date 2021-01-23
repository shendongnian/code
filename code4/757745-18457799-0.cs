    XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new System.Xml.Linq.XElement("Contacts"),
                new XElement("Contact",
                new XElement("Name", c.FirstOrDefault().DisplayName),
                new XElement("PhoneNumber", c.FirstOrDefault().PhoneNumber.ToString()),
                new XElement("Email", "abc@abc.com"));
    doc.Save(...);
    
