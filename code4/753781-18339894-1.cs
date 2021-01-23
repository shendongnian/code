    public void SerializeObject<T>(T obj)
    {
        using (StreamWriter sw = new StreamWriter("your path"))
        {
            new XmlSerializer(typeof(T)).Serialize(sw, obj);
        }
    }
    public T DeserializeObject<T>()
    {
        T obj;
        using (StreamReader sr = new StreamReader("your path"))
        {
            obj = (T)new XmlSerializer(typeof(T)).Deserialize(sr);
        }
        return obj;
    }
