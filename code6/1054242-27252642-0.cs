    public static void SerializeObject(T obj)
    {
        XmlSerializer s = new XmlSerializer(typeof(T));
        TextWriter w = new StreamWriter(file);
        s.Serialize(w, obj);
        w.Close();
    }
    
    public static T DeserializeObject(string filename)
    {
        XmlSerializer s = new XmlSerializer(typeof(T));
        using (StreamReader r = new StreamReader(file))
        {
            return (T)s.Deserialize(r);
        }
    }
