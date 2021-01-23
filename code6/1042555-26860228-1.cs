    var input = "<param>....</param>";
    var serializer = new XmlSerializer(typeof(Wrapper));
    using (TextReader reader = new StringReader(input))
    {
      result = serializer.Deserialize(reader);
      var sql = result.Param.Sql; // this would be your string you are looking for
    }
