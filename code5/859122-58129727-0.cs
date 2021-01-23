      var actualFilepath= "D:\\Video\\Sample.mp4";
      var videoBytes=ConvertVideoToBytes(actualFilepath);
      var encryptedvideoBytes=EncryptVideo(videoBytes);
      ConvertEncryptFileToFile(encryptedvideoBytes);
      var encryptedFilepath = "D:\\Video\\VideosEncryptedFile.deific";
       var readVideoBytes = ConvertVideoToBytes(encryptedFilepath);
       var decryptedVideoBytes = DecryptVideo(readVideoBytes);
       ConvertDecryptFileToFile(decryptedVideoBytes);
    
      private byte[] ConvertVideoToBytes(string filePath)
      {            
       return System.IO.File.ReadAllBytes(filePath);            
      }
       private byte[] EncryptVideo(byte[] videoBytes)
       {
            string passPhrase = "mypassphrase27092019";
            string saltValue = "mysaltvalue";
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            RijndaelCipher.Mode = CipherMode.CBC;
            byte[] salt = Encoding.ASCII.GetBytes(saltValue);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, salt, 
         "SHA1", 2);
            ICryptoTransform Encryptor = 
            RijndaelCipher.CreateEncryptor(password.GetBytes(32), password.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, 
            CryptoStreamMode.Write);
            cryptoStream.Write(videoBytes, 0, videoBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return cipherBytes;
        }
        private void ConvertEncryptFileToFile(byte[] encryptedvideoBytes)
        {
            var filePath = string.Empty;
            filePath = "D:\\Video";
            System.IO.File.WriteAllBytes(filePath+"\\VideosEncryptedFile.deific", 
         encryptedvideoBytes);
         }
        private byte[] DecryptVideo(byte[] encryptedVideoBytes)
         {
            string passPhrase = "mypassphrase27092019";
            string saltValue = "mysaltvalue";
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            RijndaelCipher.Mode = CipherMode.CBC;
            byte[] salt = Encoding.ASCII.GetBytes(saltValue);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, salt, "SHA1", 2);
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(password.GetBytes(32), password.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(encryptedVideoBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
            byte[] plainBytes = new byte[encryptedVideoBytes.Length];
            int decryptedCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return plainBytes;
        }
      private void ConvertDecryptFileToFile(byte[] decryptedVideoBytes)
        {
            var filePath = string.Empty;
            filePath = "D:\\Video";
            System.IO.File.WriteAllBytes(filePath + "\\FinalFile.mp4", 
            decryptedVideoBytes);
        }
