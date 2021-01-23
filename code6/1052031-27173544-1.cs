    Modification m = new Modification()
    {
        Name = "Autoroute",
        Value = "53"
    };
    Modification andBack = null;
            
    XmlSerializer s = new XmlSerializer(typeof(Modification), new XmlRootAttribute(m.Name));
    using (StreamWriter writer = new StreamWriter(@"c:\temp\output.xml"))
        s.Serialize(writer, m);
    using (StreamReader reader = new StreamReader(@"c:\temp\output.xml"))
        andBack = s.Deserialize(reader) as Modification;
    Console.WriteLine("{0}={1}", andBack.Name, andBack.Value);
