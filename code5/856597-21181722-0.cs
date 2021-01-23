    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(path + "\\save.xml");
    
    var xmlNodeExist = "Buchhaltung/Customers/CustNo";
    var CustNoExist = xdoc.XPathSelectElements(xmlNodeExist).FirstOrDefault(x => (int)x == CustNos);
    
    var SurnameNode = xmlDoc.SelectNodes("Buchhaltung/Customers/Surname");
    var ForenameNode = xmlDoc.SelectNodes("Buchhaltung/Customers/Forename");
    
    if (CustNoExist != null)
    {
        foreach(XmlNode xn in SurnameNode)
        {
            txtSurnameNew.Text += xn.InnerText + Environment.Newline;
        }
    
        foreach(XmlNode xn in ForenameNode)
        {
            txtForenameNew.Text += xn.InnerText + Environment.Newline;
        }
    }
