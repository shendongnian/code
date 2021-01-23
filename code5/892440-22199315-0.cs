    GenericXmlSerializer.WriteObject(anyObject,"a.xml");
---
    internal static class GenericXmlSerializer
    {
        public static void WriteObject<T>(T outputObject, string outputFile)
        {
            using (FileStream writer = new FileStream(outputFile, FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, outputObject);
            }
        }
        public static T ReadObject<T>(string objectData)
        {
            T deserializedObject = default(T);
            using (StringReader reader = new StringReader(objectData))
            {
                XmlTextReader xmlReader = new XmlTextReader(reader);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                deserializedObject = (T)ser.Deserialize(xmlReader);
                xmlReader.Close();
            }
            return deserializedObject;
        }
    } 
