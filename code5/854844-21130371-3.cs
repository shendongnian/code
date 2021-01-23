    var serviceInfo = new Serviceinfo
    {
        Profiles = new List<Profile>() {
            new Profile { Name = "one", State = 1 },
            new Profile { Name = "two", State = 2 }
        }
    };
    var writer = new StringWriter();
    var serializer = new XmlSerializer(typeof(Serviceinfo));
    serializer.Serialize(writer, serviceInfo);
    var xml = writer.ToString();
