    static HolyQuran LoadQuran(string path)
    {
        var readerSettings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore };
        using (var reader = XmlReader.Create(path, readerSettings))
        {
            var xs = new XmlSerializer(typeof(HolyQuran));
            return (HolyQuran)xs.Deserialize(reader);
        }
    }
