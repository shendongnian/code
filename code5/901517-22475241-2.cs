    public ServersList ReadServersList()
    {
        XmlSerializer xmlSer = new XmlSerializer(typeof(ServersList), new XmlRootAttribute("ServersList"));
        TextReader stringReader = new StringReader(xmlPath);
        ServersList b = (ServersList)xmlSer.Deserialize(stringReader);
        stringReader.Close();
        return b;
    }
