    static string Encrypt(string plainText, string key)
    {
      string cipherText;
      var rijndael = new RijndaelManaged()
      {
        Key = Encoding.UTF8.GetBytes(key),
        Mode = CipherMode.ECB,
        BlockSize = 128,
        Padding = PaddingMode.Zeros,
      };
      ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, null);
      using (var memoryStream = new MemoryStream())
      {
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        {
          using (var streamWriter = new StreamWriter(cryptoStream))
          {
            streamWriter.Write(plainText);
            streamWriter.Flush();
          }
          //cipherText = Convert.ToBase64String(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(memoryStream.ToArray())));
          cipherText = Convert.ToBase64String(memoryStream.ToArray());
          //cryptoStream.FlushFinalBlock();
        }
      }
      return cipherText;
    }
