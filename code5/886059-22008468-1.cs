    XDocument xDoc = XDocument.Parse(YourStringHoldingXmlContent);
    XElement xCustomer = xDoc.Element("Customer");
    foreach (XElement CustLoayalty in xCustomer.Elements("CustLoyalty"))
    {
        Console.WriteLine(CustomLoaylty.Value.ToString());
    }
