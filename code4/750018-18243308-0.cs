    public XElement CreateContact(string name, string phone, string address)
    {
        XElement contact = new XElement("Contact", 
                               new XElement("fullname", name),
                               new XElement("phoneno", phone),
                               new XElement("address", address));
        return contact;
    }
