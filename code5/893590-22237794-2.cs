        public static X509Certificate2 GenerateSelfSignedCertificate(string subjectName, string issuerName, AsymmetricKeyParameter issuerPrivKey,  int keyStrength = 2048)
    {
        // Generating Random Numbers
        var randomGenerator = new CryptoApiRandomGenerator();
        var random = new SecureRandom(randomGenerator);
    
        // The Certificate Generator
        var certificateGenerator = new X509V3CertificateGenerator();
    
        // Serial Number
        var serialNumber = BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), random);
        certificateGenerator.SetSerialNumber(serialNumber);
    
        // Signature Algorithm
        const string signatureAlgorithm = "SHA256WithRSA";
        certificateGenerator.SetSignatureAlgorithm(signatureAlgorithm);
    
        // Issuer and Subject Name
        var subjectDN = new X509Name(subjectName);
        var issuerDN = issuerName;
        certificateGenerator.SetIssuerDN(issuerDN);
        certificateGenerator.SetSubjectDN(subjectDN);
    
        // Valid For
        var notBefore = DateTime.UtcNow.Date;
        var notAfter = notBefore.AddYears(2);
    
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
        var issuerKeyPair = subjectKeyPair;
    
        // selfsign certificate
        var certificate = certificateGenerator.Generate(issuerPrivKey, random);
    
        // correcponding private key
        PrivateKeyInfo info = PrivateKeyInfoFactory.CreatePrivateKeyInfo(subjectKeyPair.Private);
    
    
        // merge into X509Certificate2
        var x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(certificate.GetEncoded());
    
        var seq = (Asn1Sequence)Asn1Object.FromByteArray(info.PrivateKey.GetDerEncoded());
        if (seq.Count != 9)
            throw new PemException("malformed sequence in RSA private key");
    
        var rsa = new RsaPrivateKeyStructure(seq);
        RsaPrivateCrtKeyParameters rsaparams = new RsaPrivateCrtKeyParameters(
            rsa.Modulus, rsa.PublicExponent, rsa.PrivateExponent, rsa.Prime1, rsa.Prime2, rsa.Exponent1, rsa.Exponent2, rsa.Coefficient);
    
        x509.PrivateKey = DotNetUtilities.ToRSA(rsaparams);
        return x509;
    
    }
    
    
    public static AsymmetricKeyParameter GenerateCACertificate(string subjectName, int keyStrength = 2048)
    {
        // Generating Random Numbers
        var randomGenerator = new CryptoApiRandomGenerator();
        var random = new SecureRandom(randomGenerator);
    
        // The Certificate Generator
        var certificateGenerator = new X509V3CertificateGenerator();
    
        // Serial Number
        var serialNumber = BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), random);
        certificateGenerator.SetSerialNumber(serialNumber);
    
        // Signature Algorithm
        const string signatureAlgorithm = "SHA256WithRSA";
        certificateGenerator.SetSignatureAlgorithm(signatureAlgorithm);
    
        // Issuer and Subject Name
        var subjectDN = new X509Name(subjectName);
        var issuerDN = subjectDN;
        certificateGenerator.SetIssuerDN(issuerDN);
        certificateGenerator.SetSubjectDN(subjectDN);
    
        // Valid For
        var notBefore = DateTime.UtcNow.Date;
        var notAfter = notBefore.AddYears(2);
    
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
        var issuerKeyPair = subjectKeyPair;
    
        // selfsign certificate
        var certificate = certificateGenerator.Generate(issuerKeyPair.Private, random);
    	var x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(certificate.GetEncoded());
    	// Add CA certificate to Root store
    	addCertToStore(cert, StoreName.Root, StoreLocation.CurrentUser);
    	
        return issuerKeyPair.Private;
    
    }
