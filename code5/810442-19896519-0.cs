    XmlDocument xd = new XmlDocument();
    xd.Load("employees.xml");
    XmlNode nl = xd.SelectSingleNode("//Employees");
    XmlDocument xd2 = new XmlDocument();
    xd2.LoadXml("<Employee><ID>20</ID><FirstName>Clair</FirstName><LastName>Doner</LastName><Salary>13000</Salary></Employee>");
    XmlNode n = xd.ImportNode(xd2.FirstChild,true);
    nl.AppendChild(n);
    xd.Save(Console.Out);
