    // Decrypt a string into a string using a key and an IV 
    public static string Decrypt(string cipherData, string keyString, string ivString)
    {
        byte[] key = Encoding.UTF8.GetBytes(keyString);
        byte[] iv = Encoding.UTF8.GetBytes(ivString);
        var decryptor = new RijndaelManaged 
            { Key = key, IV = iv, Mode = CipherMode.CBC }
            .CreateDecryptor(key, iv);
        try
        {
            using (var memoryStream = 
                new MemoryStream(Convert.FromBase64String(cipherData)))
            {
                using (var cryptoStream = 
                    new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    return new StreamReader(cryptoStream).ReadToEnd();
                }
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            return null;
        }
        // ...you may want to catch more exceptions here a'la encryption
    }
