    var reader = new XmlTextReader(@"Data.xml");
    while (reader.Read()) {
     reader.MoveToContent();
     if (reader.NodeType == XmlNodeType.Element && reader.Name == "Destination") {
     Console.WriteLine(reader.GetAttribute("location"));
     }
    }
