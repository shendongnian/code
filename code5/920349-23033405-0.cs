    private T ReadXMLFile<T>(string fullPath) {
      XmlSerializer serializer = new XmlSerializer(typeof(T));
      System.IO.StreamReader file = new System.IO.StreamReader(fullPath);
      T obj = (T)serializer.Deserialize(file);
      file.Close();
      return obj;
    }
