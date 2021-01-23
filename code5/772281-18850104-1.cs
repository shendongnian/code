    public static byte[] Encrypt(string publicKey, string data)
    {
        CspParameters cspParams = new CspParameters { ProviderType = 1 };
        RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);
     
        rsaProvider.ImportCspBlob(Convert.FromBase64String(publicKey));
     
        byte[] plainBytes = Encoding.UTF8.GetBytes(data);
        byte[] encryptedBytes = rsaProvider.Encrypt(plainBytes, false);
     
        return encryptedBytes;
    }
