    public static Param InitConfig(string Path)
    {
        XmlRootAttribute xRoot = new XmlRootAttribute();
        xRoot.ElementName = "Param";
        xRoot.IsNullable = true;
    
        XmlSerializer serializer = new XmlSerializer(typeof(MyClass), xRoot);
        using (StreamReader reader = new StreamReader(Path))
        {
            return new Param {MyClass = (MyClass)serializer.Deserialize(reader)};
        }
    }
