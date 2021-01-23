    public static class MySerializationHelper
    {
       public static class From
       {
          public TReturn XMLFile<TReturn>(string contents)
          {
             var serializer = new XmlSerializer(typeof(TReturn));
             var fs = File.Open(filePath, FileMode.Open);
             var result = (TReturn)serializer.Deserialize(fs);
             fs.Close();
             return result;
          }
       }
       public static class To
       {
          public void XMLFile<TType>(TType object, string filePath)
          {
             // Serialize it here...
          }
       }
    }
