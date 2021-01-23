    private static string _privateKey;
    private static string _publicKey;
    private static UnicodeEncoding _encoder = new UnicodeEncoding();
    
    private static void RSA()
    {
      var rsa = new RSACryptoServiceProvider();
      _privateKey = rsa.ToXmlString(true);
      _publicKey = rsa.ToXmlString(false);
        
      var text = "Test1";
      Console.WriteLine("RSA // Text to encrypt: " + text);
      var enc = Encrypt(text);
      Console.WriteLine("RSA // Encrypted Text: " + enc);
      var dec = Decrypt(enc);
      Console.WriteLine("RSA // Decrypted Text: " + dec);
    }
        
    public static string Decrypt(string data)
    {
      var rsa = new RSACryptoServiceProvider();
      var dataArray = data.Split(new char[] { ',' });
      byte[] dataByte = new byte[dataArray.Length];
      for (int i = 0; i < dataArray.Length; i++)
      {
        dataByte[i] = Convert.ToByte(dataArray[i]);
      }
        
      rsa.FromXmlString(_privateKey);
      var decryptedByte = rsa.Decrypt(dataByte, false);
      return _encoder.GetString(decryptedByte);
    }
        
    public static string Encrypt(string data)
    {
      var rsa = new RSACryptoServiceProvider();
      rsa.FromXmlString(_publicKey);
      var dataToEncrypt = _encoder.GetBytes(data);
      var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
      var length = encryptedByteArray.Count();
      var item = 0;
      var sb = new StringBuilder();
      foreach (var x in encryptedByteArray)
      {
        item++;
        sb.Append(x);
        
        if (item < length)
          sb.Append(",");
      }
        
      return sb.ToString();
    }
