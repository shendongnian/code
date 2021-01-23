    public static T Deserialize<T>(string xml)
    {
       var serializer = new XmlSerializer(Typeof(T));
       using(var textReader = new XMLTextReader(newStringReader(xml)))
       {
         return (T)serializer.Deserialize(xmlReader);
       }
    }
