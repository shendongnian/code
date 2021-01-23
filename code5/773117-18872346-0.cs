    static void Main()
    {
        var keyPair = CreateKeyPair();
        var encryptedText = Encrypt(keyPair.Item2, "test data");
        var decryptedText = Decrypt(keyPair.Item1, encryptedText);
        Console.WriteLine("Encrypted text: {0}", encryptedText);
        Console.WriteLine("Decrypted text: {0}", decryptedText);
    }
    public static string RSA_Decrypt(string encryptedText, string privateKey)
    {
        CspParameters cspParams = new CspParameters { ProviderType = 1 };
        RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);
        rsaProvider.ImportCspBlob(Convert.FromBase64String(privateKey));
        var buffer = Convert.FromBase64String(encryptedText);
        byte[] plainBytes = rsaProvider.Decrypt(buffer, false);
        string plainText = Encoding.UTF8.GetString(plainBytes, 0, plainBytes.Length);
        return plainText;
    }
    public static string RSA_Encrypt(string data, string publicKey)
    {
        CspParameters cspParams = new CspParameters { ProviderType = 1 };
        RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);
        rsaProvider.ImportCspBlob(Convert.FromBase64String(publicKey));
        byte[] plainBytes = Encoding.UTF8.GetBytes(data);
        byte[] encryptedBytes = rsaProvider.Encrypt(plainBytes, false);
        return Convert.ToBase64String(encryptedBytes);
    }
    public static Tuple<string, string> CreateKeyPair()
    {
        CspParameters cspParams = new CspParameters { ProviderType = 1 /* PROV_RSA_FULL */ };
        RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(2048, cspParams);
        string publicKey = Convert.ToBase64String(rsaProvider.ExportCspBlob(false));
        string privateKey = Convert.ToBase64String(rsaProvider.ExportCspBlob(true));
        return new Tuple<string, string>(privateKey, publicKey);
    }
