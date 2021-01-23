    private string Decoder(string originFilePath)
    {
       using (StreamReader sr = new StreamReader(originFilePath, Encoding.GetEncoding("utf-8")))
       {
          return sr.ReadToEnd();
       }
    }
