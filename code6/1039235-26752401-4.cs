    XmlDocument doc = new XmlDocument();
    doc.LoadXml(File.ReadAllText(@"PathToYourFile\file.xml"));
    XmlNode rowset = doc.SelectSingleNode("/ROWSET"); // <-- This variable provides access to the root XML node
    List<XmlNode> rows = rowset.SelectNodes("ROW").Cast<XmlNode>().ToList();
    foreach (XmlNode row in rows)
    {
        // access attibutes of row with:
        string numValue = row.Attributes["num"].InnerText;
        // access sub-elements of row with:
        string employeeNo = row.SelectSingleNode("EMPLOYEE_NO").InnerText;
        // You can even go deeper through an XML hierarchy with:
        // row.SelectSingleNode("SomeXMLNode/SubNode/NodeOfSubNode").InnerText;
    }
    // Select the 2nd row
    XmlNode secondRow = rows.Single(r => r.Attributes["num"].InnerText == "2");
