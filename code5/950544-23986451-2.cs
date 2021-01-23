    XmlDocument doc = new XmlDocument();
    doc.LoadXml(yourxml);
            
    XmlNodeList xlist = doc.GetElementsByTagName("searchlayer");
    for(int i=0;i<xlist.Count;i++)
     {
      Console.WriteLine(xlist[i].InnerText + " " + xlist[i].Attributes["whereClause"].Value);
     }
