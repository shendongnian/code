    public ActionResult Index()
    {
        WebClient client = new WebClient();
        client.Encoding = System.Text.Encoding.UTF8;
    
        var xml = client.DownloadString(Server.MapPath("doc.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        System.Xml.XmlNamespaceManager xmlnsManager = new System.Xml.XmlNamespaceManager(doc.NameTable);
        xmlnsManager.AddNamespace("ns", "http://www.opengis.net/kml/2.2");
    
        foreach (XmlNode node in doc.SelectNodes("ns:kml/ns:Document/ns:Folder"))
        {
            string teste = node.SelectSingleNode("name").InnerText;
            foreach (XmlNode node1 in node.SelectNodes("Placemark"))
            {
                string teste1 = node.SelectSingleNode("name").InnerText;
            }
        }
    
        return View();
    }
