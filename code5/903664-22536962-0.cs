    public static string ZipStr(String str)
    {
        using (MemoryStream output = new MemoryStream())
        {
            using (DeflateStream gzip = 
              new DeflateStream(output, CompressionMode.Compress))
            {
                using (StreamWriter writer = 
                  new StreamWriter(gzip, System.Text.Encoding.UTF8))
                {
                    writer.Write(str);           
                }
            }
    
            return Convert.ToBase64String(output.ToArray());
        }
    }
    
    public static string UnZipStr(string base64)
    {
        byte[] input = Convert.FromBase64String(base64);
    
        using (MemoryStream inputStream = new MemoryStream(input))
        {
            using (DeflateStream gzip = 
              new DeflateStream(inputStream, CompressionMode.Decompress))
            {
                using (StreamReader reader = 
                  new StreamReader(gzip, System.Text.Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
