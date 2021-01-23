    using System.Xml;
    using System.Xml.Serialization;
    class XmlSerialization
        {        
            public static void genericSerializeToXML<T>(T TValue, string XmalfileStorageRelativePath)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));           
                FileStream textWriter = new FileStream((string)System.IO.Path.GetFullPath(XmalfileStorageRelativePath), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                serializer.Serialize(textWriter, TValue);
                textWriter.Close();
            }
    
    
            public static T genericDeserializeFromXML<T>(T value, string XmalfileStorageFullPath)
            {          
                T Tvalue = default(T);
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(T));
                    TextReader textReader = new StreamReader(XmalfileStorageFullPath);
                    Tvalue = (T)deserializer.Deserialize(textReader);
                    textReader.Close();
    
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(@"File Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return Tvalue;
            }
        }
