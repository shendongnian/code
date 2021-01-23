    // System.Xml.XmlDocument version
    XmlDocument xd = new XmlDocument();
    xd.Load(@"C:\Projects\GetXML\testLayers.xml");
    foreach (XmlElement step in xd.SelectNodes("//*"))
    {
        Console.WriteLine("{0} = {1}", step.Name,
           step.SelectSingleNode("text()").Value);
    }
    // System.Xml.Linq.XDocument version
    XDocument xdLinq = XDocument.Load(@"C:\Projects\GetXML\testLayers.xml");
    foreach (XElement step in xdLinq.XPathSelectElements("//*"))
    {
        Console.WriteLine("{0} = {1}", step.Name, 
           step.Nodes().Where(n => n.NodeType == XmlNodeType.Text).FirstOrDefault());
    }
