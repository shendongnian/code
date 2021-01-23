    using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
    {
        provider.ImportParameters(param);
        byte[] rsaBlock = provider.Encrypt(preMasterSecret, false);
        this.Client.Writer.Write(rsaBlock);
    }
