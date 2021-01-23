    public static Anfrage Create(byte[] dis)
    {
        XmlSerializer deser = new XmlSerializer(typeof(Anfrage));
        Stream str = new MemoryStream();
        str.Write(dis, 0, dis.Length);
        return (Anfrage)deser.Deserialize(str);
    }
