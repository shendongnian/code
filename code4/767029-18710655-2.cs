    Data data = new Data(...);//create Data object
    System.Xml.Serialization.XmlSerializer xmls = new System.Xml.Serialization.XmlSerializer(typeof(Data));
    System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\myTemplate.xml");
    writer.Serialize(file, data);
    file.Close();
