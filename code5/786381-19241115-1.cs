    var serializer = new XmlSerializer(typeof(List<Items>), new XmlRootAttribute("xml"));
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
    var listOfItems = serializer.Deserialize(doc.CreateReader());
