    var kpgen = new RsaKeyPairGenerator();
    kpgen.Init(new KeyGenerationParameters(new SecureRandom(new CryptoApiRandomGenerator()), 1024));
    var keyPair = kpgen.GenerateKeyPair();
    using (var writer = new StreamWriter(File.OpenWrite(@"C:\Users\Diego\Documents\private2.pem")))
    {
        new PemWriter(writer).WriteObject(keyPair.Private);
    }
    using (var writer = new StreamWriter(File.OpenWrite(@"C:\Users\Diego\Documents\public2.pem")))
    {
        new PemWriter(writer).WriteObject(keyPair.Public);
    }
