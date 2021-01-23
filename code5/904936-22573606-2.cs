    var serializer = new XmlSerializer(typeof(Listener[]), 
                                       new XmlRootAttribute("listeners"));
    var configuration = ConfigurationManager
        .OpenExeConfiguration(ConfigurationUserLevel.None);
    var section = configuration.GetSection("listeners");
    var rawXml = section.SectionInformation.GetRawXml();
    using (var stringReader = new StringReader(rawXml))
    {
        var listeners = (Listener[])serializer.Deserialize(stringReader);
    }
