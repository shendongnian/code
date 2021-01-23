    private void Serialize(Store store, string path)
    {
        var xmlSerializer = new XmlSerializer(typeof(Store));
        using (var streamWriter = new StreamWriter(path))
        {
            xmlSerializer.Serialize(streamWriter, store);
        }
    }
    private Store Deserialize(string path)
    {
        var xmlSerializer = new XmlSerializer(typeof(Store));
        using (var streamReader = new StreamReader(path))
        {
            return xmlSerializer.Deserialize(streamReader) as Store;
        }
    }
