    // Load your pass type identifier certificate
    X509Certificate2 card = GetCertificate(request);
    Org.BouncyCastle.X509.X509Certificate cert = DotNetUtilities.FromX509Certificate(card);
    Org.BouncyCastle.Crypto.AsymmetricKeyParameter privateKey = DotNetUtilities.GetKeyPair(card.PrivateKey).Private;
    
    // Load the Apple certificate
    X509Certificate2 appleCA = GetAppleCertificate(request);
    X509.X509Certificate appleCert = DotNetUtilities.FromX509Certificate(appleCA);
    ArrayList intermediateCerts = new ArrayList();
    intermediateCerts.Add(appleCert);
    intermediateCerts.Add(cert);
    Org.BouncyCastle.X509.Store.X509CollectionStoreParameters PP = new Org.BouncyCastle.X509.Store.X509CollectionStoreParameters(intermediateCerts);
    Org.BouncyCastle.X509.Store.IX509Store st1 = Org.BouncyCastle.X509.Store.X509StoreFactory.Create("CERTIFICATE/COLLECTION", PP);
    CmsSignedDataGenerator generator = new CmsSignedDataGenerator();
    generator.AddSigner(privateKey, cert, CmsSignedDataGenerator.DigestSha1);
    generator.AddCertificates(st1);
    CmsProcessable content = new CmsProcessableByteArray(manifestFile);
    CmsSignedData signedData = generator.Generate(content, false);
    signatureFile = signedData.GetEncoded();
