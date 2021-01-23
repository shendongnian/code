    private const readonly string decryptKey = "";
    public string GetFromConfig(string key)
    {
       var encryptedText = System.Web.Configuration.WebConfigurationManager.AppSettings[key];
       var plainText = Decrypt(encryptedText, decryptKey);
       return plainText;
    }
