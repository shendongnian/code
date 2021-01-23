      var sb = new StringBuilder();
      var settings = new XmlWriterSettings {
        OmitXmlDeclaration = true,
        Indent = true,
        IndentChars = "  ",
      };
      using (var writer = XmlWriter.Create(sb, settings)) {
        writer.WriteStartElement("X");
        writer.WriteAttributeString("A", "1");
        writer.Flush();
        sb.Append("\r\n");
        writer.WriteAttributeString("B", "2");
        writer.Flush();
        sb.Append("\r\n");
        writer.WriteAttributeString("C", "3");
        writer.WriteEndElement();
      }
      Console.WriteLine(sb.ToString());
