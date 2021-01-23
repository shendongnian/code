    public void Save(string fileName, SaveOptions options)
    {
      XmlWriterSettings xmlWriterSettings = XNode.GetXmlWriterSettings(options);
      if (this.declaration != null)
      {
        if (!string.IsNullOrEmpty(this.declaration.Encoding))
        {
          try
          {
            xmlWriterSettings.Encoding = Encoding.GetEncoding(this.declaration.Encoding);
          }
          catch (ArgumentException ex)
          {
          }
        }
      }
      using (XmlWriter writer = XmlWriter.Create(fileName, xmlWriterSettings))
        this.Save(writer);
    }
