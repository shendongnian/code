    public async Task<string> FileToBase64(string filePath)
    {
        try
        {
           WebRequest request = WebRequest.Create(new Uri(filePath));
           if (request != null)
           {
               using (Stream resopnse = await request.GetRequestStreamAsync())
               using (MemoryStream temp = new MemoryStream())
               {
                   const int BUFFER_SIZE = 1024;
                   byte[] buf = new byte[BUFFER_SIZE];
                   int bytesread = 0;
                   while ((bytesread = await resopnse.ReadAsync(buf, 0, BUFFER_SIZE)) > 0)
                         temp.Write(buf, 0, bytesread);
                   return Convert.ToBase64String(temp.ToArray());
                }
            }
            return String.Empty;
       }
       catch { return String.Empty; }
    }
