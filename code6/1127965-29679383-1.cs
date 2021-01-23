    public static List<Bloc> ReadXML(string path)
    {
        System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(BlocContainer));
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        BlocContainer bc = null;
        bc = (BlocContainer)reader.Deserialize(file);
        file.Close();
        if(bc != null) { return bc.BlocCollection; } else { return new List<Bloc>(); }
    }
