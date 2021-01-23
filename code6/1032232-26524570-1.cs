    public string Serialize()
    {
      var writer = new StringWriter();
      var ns = new XmlSerializerNamespaces();
      ns.Add("", "");
      var serializer = new XmlSerializer(typeof(DiscrepancyType));
      serializer.Serialize(writer, this, ns);
      return writer.ToString();
    }
