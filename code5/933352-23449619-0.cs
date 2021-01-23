    XDocument input = XDocument.Load("customers.xml");
    XDocument output = new XDocument();
    output.Add(new XElement("Customers"));
    IEnumerable<XElement> elements = input.Element("Customers").Elements("customer");
    foreach (XElement el in elements)
    {
        string age = el.Element("Age").Value;
        string status = el.Element("Status").Value;
        if (age != "" || status != "")
        {
            output.Element("Customers").Add(el);
        }
    }
    output.Save("customers.xml");
