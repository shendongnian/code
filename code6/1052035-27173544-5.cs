    Modification modification = new Modification()
    {
        Name = "Autoroute",
        Value = "53"
    };
    Modification andBack = null;
    string rootElement = "test";    
    XmlSerializer s = new XmlSerializer(typeof(Modification), new XmlRootAttribute(rootElement));
    using (StreamWriter writer = new StreamWriter(@"c:\temp\output.xml"))
        s.Serialize(writer, modification);
    using (StreamReader reader = new StreamReader(@"c:\temp\output.xml"))
        andBack = s.Deserialize(reader) as Modification;
    Console.WriteLine("{0}={1}", andBack.Name, andBack.Value);
