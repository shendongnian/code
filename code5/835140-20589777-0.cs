    namespace DataContractSerializerExample
    {
        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.IO;
        using System.Runtime.Serialization;
        using System.Xml;
    
        // You must apply a DataContractAttribute or SerializableAttribute 
        // to a class to have it serialized by the DataContractSerializer.
         [DataContract(Name = "Vara", Namespace = "http://www.contoso.com")]
       public class Vara
        {
            [DataMember()]
            public double streckKod { get; set; }
            [DataMember]
            public string artNamn { get; set; }
        }
    
        public sealed class Test
        {
            private Test() { }
    
            public static void Main()
            {
                List<Vara> minaVaror = new List<Vara>() { new Vara() { streckKod = 5.0, artNamn = "test1" }, new Vara() { streckKod = 5.0, artNamn = "test2" }, new Vara() { streckKod = 5.0, artNamn = "test3" } };
                string fileName = "test.xml";
                Serialize<List<Vara>>(fileName, minaVaror);
                List<Vara> listDes = Deserialize<List<Vara>>(fileName);  
                
                
               
             
                
                
            }
    
            public static void Serialize<T>(string fileName,T obj )
            {           
                FileStream writer = new FileStream(fileName, FileMode.Create);
                DataContractSerializer ser =
                    new DataContractSerializer(typeof(T));
                ser.WriteObject(writer, obj);
                writer.Close(); 
            }
    
            public static T Deserialize<T>(string fileName)
            {
                FileStream fs = new FileStream(fileName,
                FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(T));                        
                T  des  =
                    (T)ser.ReadObject(reader, true);
                reader.Close();
                fs.Close();
                return des;  
            }
        }
    }
