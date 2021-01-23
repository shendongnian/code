    XmlNamespaceManager nsManager = new XmlNamespaceManager(new NameTable());
    //register ns prefix to point to default namespace 
    nsManager.AddNamespace("ns", node.FirstChild.GetNamespaceOfPrefix(""));
    //use the namespace manager and registered prefix to get desired element
    string xpath = "/ns:AdvancedListSupportClass/ns:AdvancedListSupportClass.Parameters/ns:QueryParameter";
    var queryParameters = node.SelectNodes(xpath, nsManager);
    foreach(XmlNode queryParameter in queryParameters)
    {
    	//get value of Parameter attribute of each <QueryParameter>
    	Console.WriteLine(queryParameter.Attributes["Parameter"].Value);
    }
