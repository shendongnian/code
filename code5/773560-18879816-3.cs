    public static string Dehydrate<T>( T instance )
    {
      XmlSerializer serializer = new XmlSerializer(typeof(T));
      StringBuilder sb = new StringBuilder() ;
      using ( StringWriter writer = new StringWriter( sb ) )
      {
        serializer.Serialize(writer,instance) ;
      }
      string xml = sb.ToString() ;
      return xml ;
    }
