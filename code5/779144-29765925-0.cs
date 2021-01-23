    public string StringToDecrypt(string text)
    {
        byte[] toDecrypt = Convert.FromBase64String(text);
        AsymmetricCipherKeyPair keyPair;
        using (var reader = File.OpenText(@"Private Key File Path"))
        {
            keyPair = (AsymmetricCipherKeyPair) new PemReader(reader).ReadObject();   
        }
        var engine = new RsaEngine();
        engine.Init(false, keyPair.Private);
        return Encoding.UTF8.GetString(engine.ProcessBlock(toDecrypt, 0, toDecrypt.Length));
    }
