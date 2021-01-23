    StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("output.xml", CreationCollisionOption.ReplaceExisting);
    using (IRandomAccessStream writeStream = await file.OpenAsync(FileAccessMode.ReadWrite))
    {
      System.IO.Stream s =  writeStream.AsStreamForWrite();
      System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
      settings.Async = true;
      using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(s, settings))
      {
        // Do stuff...
        await writer.FlushAsync();
      }
    }
