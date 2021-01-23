    public static class EncryptionManagement
    {
      private static SymmetricAlgorithm encryption;
      private const string password = "admin";
      private const string Mkey = "MY SECRET KEY";
      private static void Init()
      {
        encryption = new RijndaelManaged();
        var key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(Mkey));
        encryption.Key = key.GetBytes(encryption.KeySize / 8);
        encryption.IV = key.GetBytes(encryption.BlockSize / 8);
        encryption.Padding = PaddingMode.PKCS7;
      }
      public static void Encrypt(Stream inStream, Stream OutStream)
      {
        Init();
        var encryptor = encryption.CreateEncryptor();
        inStream.Position = 0;
        var encryptStream = new CryptoStream(OutStream, encryptor, CryptoStreamMode.Write);
        inStream.CopyTo(encryptStream);
        encryptStream.FlushFinalBlock();
      }
      public static void Decrypt(Stream inStream, Stream OutStream)
      {
        Init();
        var encryptor = encryption.CreateDecryptor();
        inStream.Position = 0;
        var encryptStream = new CryptoStream(inStream, encryptor, CryptoStreamMode.Read);
        encryptStream.CopyTo(OutStream);
        OutStream.Position = 0;
      }
    }
