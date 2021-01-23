    public interface MXmlSerializable { }
    public static class XmlSerializable {
      public static string ToXml(this MXmlSerializable self) {
        if (self == null) throw new ArgumentNullException();
        var serializer = new XmlSerializer(self.GetType());
        using (var writer = new StringWriter()) {
          serializer.Serialize(writer, self);
          return writer.GetStringBuilder().ToString();
        }
      }
    }
