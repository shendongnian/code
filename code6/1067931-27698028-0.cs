    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    //USAGE:
    
    //To Serialize a Serializable class:
        //string serialized = XMLManager.Save<ClassToSerialize>(classInstance);
    
    //To Deserialize a Serializable class from a serialized string:
        //ClassToSerialize classInstance = XMLManager.Load<ClassToSerialize>(serializedString);
    
    public static class XMLManager
    {
        public static string Save<T>(T data)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            StringWriter write = new StringWriter();
            xml.Serialize(write, data);
    
            return write.ToString();
        }
    
        public static T Load<T>(string xmlString) where T : class
        {
            try
            {
                StringReader outStream = new StringReader(xmlString);
                XmlSerializer xml = new XmlSerializer(typeof(T));
                return (T)xml.Deserialize(outStream);
            }
            catch (Exception e)
            {
                //error here
                throw new Exception("XMLManager caught an Exception!", e);
            }
        }
    }
