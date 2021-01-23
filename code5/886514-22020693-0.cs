    using System.Text;
    using System.Xml;
    static string EncodeText(string unescapedText) {
      if (string.IsNullOrEmpty(unescapedText)) {
        return unescapedText;
      }
      var builder = new StringBuilder(unescapedText.Length);
      using (var writer = XmlTextWriter.Create(builder, new XmlWriterSettings {
        ConformanceLevel = ConformanceLevel.Fragment
      })) {
        writer.WriteValue(unescapedText);
      }
      return builder.ToString();
    }
