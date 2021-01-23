    XmlNode MyNode = MyDoc.SelectSingleNode("SmPpProperties/SmProperties/Job");
    Console.WriteLine(String.Concat("Name: ", MyNode.Attributes["Name"].Value));
    Console.WriteLine(String.Concat("CreatedDate: ", MyNode.Attributes["CreatedDate"].Value));
    Console.WriteLine(String.Concat("ModifiedDate: ", MyNode.Attributes["ModifiedDate"].Value));
    Console.WriteLine(String.Concat("NuclearSystem: ", MyNode.InnerText));
