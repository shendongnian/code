    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(xml);
    
    foreach (XmlNode xmlTitle in xmlDoc.SelectNodes("//title"))
    {
        XmlNode xmlDescription = xmlTitle.ParentNode.SelectSingleNode("description");
        XmlNode xmlPubDate = xmlTitle.ParentNode.SelectSingleNode("pubDate");
    
        if (xmlDescription != null && xmlPubDate != null)
        {
            // Instead of printing to console PUT HERE your code to insert data into database
    
            Console.WriteLine(xmlTitle.InnerText);
            Console.WriteLine(xmlDescription.InnerText);
            Console.WriteLine(xmlPubDate.InnerText);
            Console.WriteLine();
        }
    }
