     public static String AES_decrypt(string encrypted)
        {
            encrypted = encrypted.Replace(' ', '+');// This line resolved my Issue
            var Key = Encoding.UTF8.GetBytes("AMINHAKEYTEM32NYTES1234567891234");
            var IV = Encoding.UTF8.GetBytes("7061737323313233");
            byte[] encryptedBytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Key;
            aes.IV = IV;
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            crypto.Dispose();
            return System.Text.ASCIIEncoding.ASCII.GetString(secret);
        }
