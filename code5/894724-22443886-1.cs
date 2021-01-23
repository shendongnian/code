    const string xmlString = "<customer><cust id=\"1\"><id>120</id><name>hello</name></cust><cust id=\"2\"><name>hello12</name><id>12012</id></cust></customer>";
    XmlDocument xml = new XmlDocument();
    xml.LoadXml(xmlString);
    XmlNode root = xml["customer"];
    CustomerCollection customers = new CustomerCollection();
    
    foreach (XmlNode node in root.ChildNodes)
        customers.Add(new Customer(int.Parse(node.Attributes["id"].Value))
            {
                Id = int.Parse(node["id"].InnerText),
                Name = node["name"].InnerText
            });
    propertyGrid.SelectedObject = customers;
