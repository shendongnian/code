    XmlDocument doc = new XmlDocument();
    doc.Load(path); // Where path is the location of the XML file
    
    XmlNodeList nodes = doc.DocumentElement.SelectNodes("RetrieveDeviceListResponse");
    
    for (int i = 0; i < nodes.Count; i++)
    {
        Console.WriteLine("Parent Node - {0}", nodes[i].InnerText);
        for(int j = 0; j < nodes[i].ChildNodes.Count; j++)
        {
            Console.WriteLine("Child Node - {0}", nodes[i].ChildNodes[j].InnerText);
        }
    }
