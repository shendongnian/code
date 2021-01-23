    static List<YourSettingsClass> DeserializeFromXML(string path)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<YourSettingsClass>));
        TextReader textReader = new StreamReader(path);
        List<YourSettingsClass> settings;
        settings = (List<YourSettingsClass>)deserializer.Deserialize(textReader);
        textReader.Close();
        return settings;
    }
