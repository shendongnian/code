         public string Encrypt(byte[] encryptedData)
        {
            byte[] newClearData = rijndaelEncryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
         //   return Encoding.ASCII.GetString(newClearData);
            return Convert.ToBase64String(newClearData);
        }
