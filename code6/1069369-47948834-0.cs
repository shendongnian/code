    using (RSACng rsa = new RSACng())
    {
        rsa.FromXmlString(pubkeyXml);
        byte[] blob = rsa.Key.Export(CngKeyBlobFormat.GenericPublic);
        var creationParams = new CngKeyCreationParameters();
        creationParams.Parameters.Add(
            new CngProperty(
                CngKeyBlobFormat.GenericPublic.Format,
                blob,
                CngPropertyOptions.Persist));
        using (CngKey cngKey = CngKey.Create(CngAlgorithm.Rsa, keyName, creationParams));
        {
            // The key now exists as a named key until/unless you call CngKey.Delete.
        }
    }
 
    // And elsewhere
    using (CngKey cngKey = CngKey.Open(keyName))
    using (RSA rsa = new RSACng(cngKey))
    {
        return rsa.VerifyData(
            data,
            signature,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1);
    }
