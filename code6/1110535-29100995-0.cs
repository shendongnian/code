    public static string ToXML<T>(object obj)
    {
      StringBuilder outputXml = new StringBuilder();
      using (var stringwriter = new StringWriter(outputXml))
      {
        // Define a blank/empty Namespace that will allow the generated
        // XML to contain no Namespace declarations.
        XmlSerializerNamespaces emptyNS = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
        var serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(stringwriter, obj, emptyNS);
      }
      return outputXml.ToString();
    }
