      public class SerializationHelper
        {
            public static void SerializeToXML<T>(T t, String inFilename) where T : class
            {
                StreamWriter textWriter = null;
    
                try
                {
                    var serializer = new XmlSerializer(t.GetType());
                    textWriter = new StreamWriter(inFilename);
                    serializer.Serialize(textWriter, t);
    
                }
                finally
                {
                    if (textWriter != null) textWriter.Close();
                }
            }
    
            public static T DeserializeFromXML<T>(String inFilename) where T : class
            {
                TextReader textReader = null;
                T retVal = default(T);
                try
                {
                    var deserializer = new XmlSerializer(typeof(T));
                    textReader = new StreamReader(inFilename);
                    retVal = (T)deserializer.Deserialize(textReader);
                    return retVal;
    
                }
                finally
                {
                    if (textReader != null) textReader.Close();
                }
            }
        }
