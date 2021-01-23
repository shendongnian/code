    string localPath = Server.MapPath("~/App_Data/Foods.xml");
    XmlDocument doc = new XmlDocument();
    doc.Load(localPath);
    XmlNodeList items = doc.SelectNodes("Categories/Category[Name='Fruit']/Items/Item");
    foreach(XmlNode item in items)
    {
    	Console.WriteLine(item.InnerText);
    }
