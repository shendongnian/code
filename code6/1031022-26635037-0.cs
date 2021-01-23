      string xmlResult;
      Installation installation = new Installation();
      XmlSerializer serializer = new XmlSerializer(typeof(Installation));
      using (var sw = new StringWriter())
      {
          var xw = XmlWriter.Create(sw);
          serializer.Serialize(xw, installation);
          xmlResult = sw.ToString();
      }
