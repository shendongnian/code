    using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
    {
      using (var xmlReader = XmlReader.Create(filStream))
      {
        if (partwiseSerializer.CanDeserialize(xmlReader))
        {
           var result = partwiseSerializer.Deserialize(xmlReader);
        }
        else
        {
           var result = timewiseSerializer.Deserialize(xmlReader);
        }
      }
    }
