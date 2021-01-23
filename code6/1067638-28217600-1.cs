    public void SignWithBouncyCastle(Collection<X509Certificate2> netCertificates)
    {
    	// first cert have to be linked with private key
    	var signCert = netCertificates[0];
    	var Cert = Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(signCert); 
    
    	var data = Encoding.ASCII.GetBytes(Cert.SubjectDN.ToString());
    
    	var bcCertificates = netCertificates.Select(_ => Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(_)).ToList();
    	var x509Certs = X509StoreFactory.Create("Certificate/Collection", new X509CollectionStoreParameters(bcCertificates));
    
    	var msg = new CmsProcessableByteArray(data);
    	var gen = new CmsSignedDataGenerator();
    	var privateKey = Org.BouncyCastle.Security.DotNetUtilities.GetKeyPair(signCert.PrivateKey).Private;
    	gen.AddSigner(privateKey, Cert, CmsSignedDataGenerator.DigestSha256);
    	gen.AddCertificates(x509Certs);
    
    	var signature = gen.Generate(msg, false).GetEncoded();
    	Trace.TraceInformation("signed");
    
    	CheckSignature(data, signature);
    	Trace.TraceInformation("checked");
    	try
    	{
    		CheckSignature(new byte[100], signature);
    	}
    	catch (CryptographicException cex)
    	{
    		Trace.TraceInformation("signature was checked for modified data '{0}'", cex.Message);
    	}
    }
    
    void CheckSignature(byte[] data, byte[] signature)
    {
    	var ci = new ContentInfo(data);
    	SignedCms signedCms = new SignedCms(ci, true);
    	signedCms.Decode(signature);
    	foreach (X509Certificate cert in signedCms.Certificates)
    		Trace.TraceInformation("certificate found {0}", cert.Subject);
    	signedCms.CheckSignature(true);
    }
