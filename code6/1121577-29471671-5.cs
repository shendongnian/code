    public static void Main(string[] args)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(Head));
        TextReader reader = new StreamReader("file.xml");
        Head obj = (Head)deserializer.Deserialize(reader);
        reader.Close();
    }
