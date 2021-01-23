    private static void customXmlSerialization()
    {
        Employee employee = new Employee() { personnel_id = "1202", dob = "19470906" };
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("ns0", "http://hsd.sd.com");
        XmlSerializer serializer = new XmlSerializer(typeof(Employee));
        
        string path = @"e:\temp\data.xml";
        XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
        serializer.Serialize(writer, employee,ns);
    }
