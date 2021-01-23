    using System.Xml;
    List<string> dob = new List<string>();
    XmlDocument doc = new XmlDocument();
    doc.Load("abc.xml");
    XmlNode root = doc.DocumentElement;
    foreach (XmlNode node1 in root.ChildNodes)
    {
            foreach (XmlNode node2 in node1.ChildNodes)
            {
                   if (node2.Name.ToString() == "DOB")
                    dob.Add(node2.InnerText.ToString());
            }
    }
