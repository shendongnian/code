      public static byte[] DecryptRJ256(string prm_key, string prm_iv, string prm_text_to_decrypt)
      {
            var sEncryptedString = prm_text_to_decrypt;
            var myRijndael = new RijndaelManaged();
            myRijndael.Padding = PaddingMode.Zeros;
            myRijndael.Mode = CipherMode.CBC;
            myRijndael.KeySize = 256;
            myRijndael.BlockSize = 256;
            byte[] key;
            byte[] IV;
            key = Encoding.ASCII.GetBytes(prm_key);
            IV = Encoding.ASCII.GetBytes(prm_iv);
            var decryptor = myRijndael.CreateDecryptor(key, IV);
            var sEncrypted = Convert.FromBase64String(sEncryptedString);
            var fromEncrypt = new byte[sEncrypted.Length];
            var msDecrypt = new MemoryStream(sEncrypted);
            var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
            //Return (System.Text.Encoding.ASCII.GetString(fromEncrypt))
            return fromEncrypt;
      }
