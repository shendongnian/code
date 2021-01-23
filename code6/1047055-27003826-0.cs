    var myObject = LoadFromXmlString<DATA_PROVIDERS>(xmlData);
    public static T LoadFromXmlString<T>(string xml)
    {
      T retval = default(T);
      try
      {
        XmlSerializer s = new XmlSerializer(typeof(T));
        MemoryStream ms = new MemoryStream(ASCIIEncoding.Default.GetBytes(xml));
        retval = (T)s.Deserialize(ms);
        ms.Close(); 
      }
      catch (Exception ex)
      {
        ex.Data.Add("Xml String", xml);
        throw new Exception("Error loading from XML string.  See data.", ex);
      }
      return retval;
    }
