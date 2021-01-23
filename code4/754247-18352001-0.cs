    [DataContract]
    public class MyObject {
      [DataMember]
      public string id { get; set; }
      [DataMember]
      public string key { get; set; }
      [DataMember]
      public string self { get; set; }
    }
    
    public T FromJson<T>(string value) {
      var serializer = new DataContractJsonSerializer(typeof(T));
      T result;
      using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(value), false)) {
        result = (T)serializer.ReadObject(stream);
      }
      return result;
    }
 
