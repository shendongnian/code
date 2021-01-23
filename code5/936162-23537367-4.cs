    public static ServersList LoadServersList()
    {
        var serializer = new XmlSerializer(typeof(ServersList));
        var configFile = ConfigurationManager.AppSettings["ServerListPath"];
        using (var reader = new StreamReader(configFile))
        {
            return (ServersList)serializer.Deserialize(reader);
        }
    }
