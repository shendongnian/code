    // location to store the XML file following relative path will store outside solution folder with
    // TestResults folder
    string xmlFileRelativePath = "../../../TestClientInfo.xml";
    
    public List<ClientDetails> ListClientConfig = new List<ClientDetails>();
                ClientDetails Client1 = new Classes.ClientDetails();
                Client1.ClientType = "Standard";
                Client1.clientCode = "xxx";
                Client1.Username = "username";
                Client1.Password = "password";
    
       ClientDetails Client2 = new Classes.ClientDetails();
                Client2.ClientType = "Easy";
                Client2.clientCode = "xxxx";
                Client2.Username = "username";
                Client2.Password = "password";
    
    ListClientConfig.Add(Client1);
    ListClientConfig.Add(Client2);
    
    XmlSerialization.genericSerializeToXML(ListClientConfig, xmlFileRelativePath );
