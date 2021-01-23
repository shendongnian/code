        using (var memStream = new MemoryStream())
        {
            using (var writer = new StreamWriter(memStream))
            {
                writer.Write(reader.ReadToEnd());
                writer.Flush();
                memStream.Position = 0;
                blob.UploadFromStream(memStream);
            }
        }
  
