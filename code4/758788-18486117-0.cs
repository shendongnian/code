    using System;
    using System.IO;
    namespace ConsoleApplication2
    {
      using System.Runtime.Serialization;
      using System.Xml;
    
      public interface ISerializable
      {
        void Serialize<T>(T obj, string xmlFile);
    
        T Deserialize<T>(string xmlFile);
      }
      public class Serializable : ISerializable
      {
        public void Serialize<T>(T obj, string xmlFile)
        {
          Stream xmlStream = null;
          try
          {
            xmlStream = new MemoryStream();
            var dcSerializer = new DataContractSerializer(typeof(T));
            dcSerializer.WriteObject(xmlStream, obj);
            xmlStream.Position = 0;
    
            // todo Save the file here USE DATACONTRACT
    
          }
      catch (Exception e)
      {
        throw new XmlException("XML error", e);
      }
      finally
      {
        if (xmlStream != null)
        {
          xmlStream.Close();
        }
      }
    }
     public T Deserialize<T>(string xmlFile)
    {
      FileStream fs = null;
      try
      {
        fs = new FileStream(xmlFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        if (fs.CanSeek)
        {
          fs.Position = 0;
        }
        var dcSerializer = new DataContractSerializer(typeof(T));
        var value = (T)dcSerializer.ReadObject(fs);
        fs.Close();
        return value;
      }
      catch (Exception e)
      {
        throw new XmlException("XML error", e);
      }
      finally
          {
         if (fs != null)
            {
              fs.Close();
            }
          }
        }
      }    
      [DataContract]
      public class A
      {
        [DataMember]
        public int Test { get; set; }
      }
    
      public class test
      {
        public test()
        {
          var a = new A { Test = 25 };
    
          var ser = new Serializable();
          ser.Serialize(a, "c:\\test.xml");
          var a2 = ser.Deserialize<A>("c:\test.xml");
    
          if (a2.Test == a.Test)
            Console.WriteLine("Done");
        }
      }
    
