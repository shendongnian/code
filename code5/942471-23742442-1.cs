    using(BinaryWriter bWriter = new BinaryWriter(writer.BaseStream))
    using(MemoryStream ms = new MemoryStream())
    {
       img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
       byte[] buffer = new byte[ms.Length];
       ms.Seek(0, SeekOrigin.Begin);
       ms.Read(buffer, 0, buffer.Length);
       bWriter.Write(buffer.Length);
       bWriter.Write(buffer);
    }
      
