    var doc = new XmlDocument();
    doc.Load(@"C:\Program Files\Config.xml");
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
    nsmgr.AddNamespace("ns", "event_collection/WinCollect");
    var xpath = "ns:Service[@name='InfoRepositoryClient']/ns:Environment/ns:Parameter[@name='ORBPreferredInterfaces']";
    var parameter = doc.DocumentElement.SelectSingleNode(xpath, nsmgr); 
    string value = parameter.Attributes["value"].Value;
