    public class JavaScriptStringSerializer {
      public string SerializeString<T>(T value) {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
        byte[] buffer;
        using (MemoryStream stream = new MemoryStream())
        {
          serializer.WriteObject(stream, value);
          buffer = stream.ToArray();
        }
        return Encoding.UTF8.GetString(buffer);
      }
      public T DeserializeString<T>(string value) {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
        T result;
        byte[] buffer = Encoding.UTF8.GetBytes(value);
        using (MemoryStream stream = new MemoryStream(buffer, false)) {
          result = (T)serializer.ReadObject(stream);
        }
        return result;
      }
    }
