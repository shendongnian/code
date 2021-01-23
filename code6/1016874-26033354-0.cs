    byte[] b = new byte[fi.Length];
    UTF8Encoding temp = new UTF8Encoding(true);
    //Open the stream and read it back.
    using (FileStream fs = fi.OpenRead())
    {
         using (MemoryStream ms = new MemoryStream(b))
         {
             while (fs.Read(b, 0, b.Length) > 0)
             {
                 ms.Write(b, 0, b.Length);
             }
         }
    }
