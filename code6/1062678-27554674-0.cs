    ...
    RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)pk.PrivateKey;
    
    CspParameters cspp = new CspParameters();
    cspp.KeyContainerName = rsa.CspKeyContainerInfo.KeyContainerName;
    cspp.ProviderName = rsa.CspKeyContainerInfo.ProviderName;
    // cspp.ProviderName = "Microsoft Smart Card Key Storage Provider";
    
    cspp.ProviderType = rsa.CspKeyContainerInfo.ProviderType;
    
    cspp.Flags = CspProviderFlags.NoPrompt;
    
    RSACryptoServiceProvider rsa2 = new RSACryptoServiceProvider(cspp);
    
    rsa.PersistKeyInCsp = true;
    ...
    MakeSignature.SignDetached(...);
