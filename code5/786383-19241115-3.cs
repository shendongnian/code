    var doc = XDocument.Parse(
        @"<?xml version=""1.0"" encoding=""iso-8859-1""?>
        <xml>
            <Items>
                <Property1 />
                <Property2 />
            </Items>
            <Items>
                <Property1 />
                <Property2 />
            </Items>
        </xml>");
    var serializer = new XmlSerializer(typeof(List<Items>), new XmlRootAttribute("xml"));
    List<Items> list = (List<Items>)serializer.Deserialize(doc.CreateReader());
