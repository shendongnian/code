    private void button_Click(object sender, EventArgs e)
    {
        AsymmetricKeyParameter myCAprivateKey = null;
        // Generate a root CA cert and obtain the privateKey
        X509Certificate2 MyRootCAcert = GenerateCACertificate("CN=MYTESTCA", ref myCAprivateKey);
        // Add CA certificate to store
        addCertToStore(MyRootCAcert, StoreName.Root, StoreLocation.LocalMachine);
        // Generate certificate based on the CA certificate privateKey
        X509Certificate2 MyCert = GenerateSelfSignedCertificate("CN=127.0.01", "CN=MYTESTCA", myCAprivateKey);
        // Add certificate to store
        addCertToStore(MyCert, StoreName.My, StoreLocation.LocalMachine);
        MessageBox.Show("Done!");
    }
    public static X509Certificate2 GenerateSelfSignedCertificate(string subjectName, string issuerName, AsymmetricKeyParameter issuerPrivKey)
    {
        const int keyStrength = 2048;
        // Generating Random Numbers
        CryptoApiRandomGenerator randomGenerator = new CryptoApiRandomGenerator();
        SecureRandom random = new SecureRandom(randomGenerator);
        // The Certificate Generator
        X509V3CertificateGenerator certificateGenerator = new X509V3CertificateGenerator();
        // Serial Number
        BigInteger serialNumber = BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), random);
        certificateGenerator.SetSerialNumber(serialNumber);
        // Signature Algorithm
        const string signatureAlgorithm = "SHA256WithRSA";
        certificateGenerator.SetSignatureAlgorithm(signatureAlgorithm);
        // Issuer and Subject Name
        X509Name subjectDN = new X509Name(subjectName);
        X509Name issuerDN = new X509Name(issuerName);
        certificateGenerator.SetIssuerDN(issuerDN);
        certificateGenerator.SetSubjectDN(subjectDN);
        // Valid For
        DateTime notBefore = DateTime.UtcNow.Date;
        DateTime notAfter = notBefore.AddYears(2);
        certificateGenerator.SetNotBefore(notBefore);
        certificateGenerator.SetNotAfter(notAfter);
        // Subject Public Key
        AsymmetricCipherKeyPair subjectKeyPair;
        var keyGenerationParameters = new KeyGenerationParameters(random, keyStrength);
        var keyPairGenerator = new RsaKeyPairGenerator();
        keyPairGenerator.Init(keyGenerationParameters);
        subjectKeyPair = keyPairGenerator.GenerateKeyPair();
        certificateGenerator.SetPublicKey(subjectKeyPair.Public);
        // Generating the Certificate
        AsymmetricCipherKeyPair issuerKeyPair = subjectKeyPair;
        // Selfsign certificate
        Org.BouncyCastle.X509.X509Certificate certificate = certificateGenerator.Generate(issuerPrivKey, random);
        // Correcponding private key
        PrivateKeyInfo info = PrivateKeyInfoFactory.CreatePrivateKeyInfo(subjectKeyPair.Private);
        // Merge into X509Certificate2
        X509Certificate2 x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(certificate.GetEncoded());
        Asn1Sequence seq = (Asn1Sequence)Asn1Object.FromByteArray(info.PrivateKey.GetDerEncoded());
        if (seq.Count != 9)
        {
            //throw new PemException("malformed sequence in RSA private key");
        }
        RsaPrivateKeyStructure rsa = new RsaPrivateKeyStructure(seq);
        RsaPrivateCrtKeyParameters rsaparams = new RsaPrivateCrtKeyParameters(
            rsa.Modulus, rsa.PublicExponent, rsa.PrivateExponent, rsa.Prime1, rsa.Prime2, rsa.Exponent1, rsa.Exponent2, rsa.Coefficient);
        x509.PrivateKey = DotNetUtilities.ToRSA(rsaparams);
        return x509;
    }
    public static X509Certificate2 GenerateCACertificate(string subjectName, ref AsymmetricKeyParameter CaPrivateKey)
    {
        const int keyStrength = 2048;
        // Generating Random Numbers
        CryptoApiRandomGenerator randomGenerator = new CryptoApiRandomGenerator();
        SecureRandom random = new SecureRandom(randomGenerator);
        // The Certificate Generator
        X509V3CertificateGenerator certificateGenerator = new X509V3CertificateGenerator();
        // Serial Number
        BigInteger serialNumber = BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), random);
        certificateGenerator.SetSerialNumber(serialNumber);
        // Signature Algorithm
        const string signatureAlgorithm = "SHA256WithRSA";
        certificateGenerator.SetSignatureAlgorithm(signatureAlgorithm);
        // Issuer and Subject Name
        X509Name subjectDN = new X509Name(subjectName);
        X509Name issuerDN = subjectDN;
        certificateGenerator.SetIssuerDN(issuerDN);
        certificateGenerator.SetSubjectDN(subjectDN);
        // Valid For
        DateTime notBefore = DateTime.UtcNow.Date;
        DateTime notAfter = notBefore.AddYears(2);
        certificateGenerator.SetNotBefore(notBefore);
        certificateGenerator.SetNotAfter(notAfter);
        // Subject Public Key
        AsymmetricCipherKeyPair subjectKeyPair;
        KeyGenerationParameters keyGenerationParameters = new KeyGenerationParameters(random, keyStrength);
        RsaKeyPairGenerator keyPairGenerator = new RsaKeyPairGenerator();
        keyPairGenerator.Init(keyGenerationParameters);
        subjectKeyPair = keyPairGenerator.GenerateKeyPair();
        certificateGenerator.SetPublicKey(subjectKeyPair.Public);
        // Generating the Certificate
        AsymmetricCipherKeyPair issuerKeyPair = subjectKeyPair;
        // Selfsign certificate
        Org.BouncyCastle.X509.X509Certificate certificate = certificateGenerator.Generate(issuerKeyPair.Private, random);
        X509Certificate2 x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(certificate.GetEncoded());
        CaPrivateKey = issuerKeyPair.Private;
        return x509;
        //return issuerKeyPair.Private;
    }
    public static bool addCertToStore(System.Security.Cryptography.X509Certificates.X509Certificate2 cert, System.Security.Cryptography.X509Certificates.StoreName st, System.Security.Cryptography.X509Certificates.StoreLocation sl)
    {
        bool bRet = false;
        try
        {
            X509Store store = new X509Store(st, sl);
            store.Open(OpenFlags.ReadWrite);
            store.Add(cert);
            store.Close();
        }
        catch
        {
        }
        return bRet;
    }
