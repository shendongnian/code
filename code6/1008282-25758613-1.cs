    string xml1;
    using (var writer = new StringWriter()) 
    {
      XmlSerializer ser = new XmlSerializer(Sheet1.GetType());
      ser.Serialize(writer, Sheet1);
      xml1 = writer.ToString();
    }
