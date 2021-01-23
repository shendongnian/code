    byte[] bytes = SomeMethodToConvertHexToBytes( encryptedText );
    byte[] key = Convert.FromBase64String( keyInBase64 );
    string decryptedText = null;
    using (RijndaelManaged algorithm = new RijndaelManaged())
    {
        // initialize settings to match those used by CF
        algorithm.Mode = CipherMode.ECB;
        algorithm.Padding = PaddingMode.PKCS7;
        algorithm.BlockSize = 128;
        algorithm.KeySize = 128;
        algorithm.Key = key;
        ICryptoTransform decryptor = algorithm.CreateDecryptor();
        using (MemoryStream msDecrypt = new MemoryStream(bytes))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
               using (StreamReader srDecrypt = new StreamReader(csDecrypt))
               {
                   decryptedText = srDecrypt.ReadToEnd();
               }
            }
        }
    }
    Console.WriteLine("Encrypted String: {0}", encryptedText);
    Console.WriteLine("Decrypted String: {0}", decryptedText);
