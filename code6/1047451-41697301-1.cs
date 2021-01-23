    private String AES_decrypt(string encrypted,String secretKey,String initVec)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encrypted);
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        //aes.BlockSize = 128; Not Required
        //aes.KeySize = 256; Not Required
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.Pkcs7;
        aes.Key = Encoding.UTF8.GetBytes(secretKey);PSVJQRk9QTEpNVU1DWUZCRVFGV1VVT0=
        aes.IV = Encoding.UTF8.GetBytes(initVec); //2314345645678765
        ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
        byte[] secret = crypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        crypto.Dispose();
        return System.Text.ASCIIEncoding.ASCII.GetString(secret);
    }
