    public static string Decrypt(string privateKey, byte[] encryptedBytes)
    {
        CspParameters cspParams = new CspParameters { ProviderType = 1 };
        RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);
     
        rsaProvider.ImportCspBlob(Convert.FromBase64String(privateKey));
     
        byte[] plainBytes = rsaProvider.Decrypt(encryptedBytes, false);
     
        string plainText = Encoding.UTF8.GetString(plainBytes, 0, plainBytes.Length);
     
        return plainText;
    }
