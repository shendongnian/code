    XmlDocument xml = new XmlDocument();
    xml.LoadXml(myXmlString);
    
    XmlNodeList xnList = xml.SelectNodes("/data/Table");
    foreach (XmlNode xn in xnList)
    {
      string USERNAME= xn["USERNAME"].InnerText;
      string STRID_FK= xn["STRID_FK"].InnerText;
      string MERID_FK= xn["MERID_FK"].InnerText;
      Console.WriteLine("Name: {0, {1}, {2}", USERNAME, STRID_FK,MERID_FK);
    }
