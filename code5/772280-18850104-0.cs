    public static Tuple<string, string> CreateKeyPair()
    {
        CspParameters cspParams = new CspParameters { ProviderType = 1 };
     
        RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(1024, cspParams);
     
        string publicKey = Convert.ToBase64String(rsaProvider.ExportCspBlob(false));
        string privateKey = Convert.ToBase64String(rsaProvider.ExportCspBlob(true));
     
        return new Tuple<string, string>(privateKey, publicKey);
    }
