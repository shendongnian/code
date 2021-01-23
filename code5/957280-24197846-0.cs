    XElement root = new XElement("qcs");
    XElement goal_Name = new XElement("goal", new System.Xml.Linq.XAttribute("name", "abc"));
    root.Add(goal_Name);
    XDocument doc = new XDocument(new XDeclaration("1.0", "ISO-8859-1", string.Empty), root);
    var wr = new StringWriter();
    doc.Save(wr);
    Console.Write(wr.GetStringBuilder().ToString());
    Console.ReadLine();
