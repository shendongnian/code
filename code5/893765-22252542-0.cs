    public static byte[] Sign(Stream inData, string certSubject)
    {
    
    	// Access Personal (MY) certificate store of current user
    	X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    	my.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
    
    	var foundCerts = my.Certificates.Find(X509FindType.FindBySubjectName, certSubject, true);
    	if (foundCerts.Count == 0)
    		throw new Exception("No valid cert was found");
    
    	var cert = foundCerts[0];
    	RSACryptoServiceProvider csp = null;
    	// let us assume that certSubject is unique
    	if (cert.HasPrivateKey)
    	{
    		csp = (RSACryptoServiceProvider)cert.PrivateKey;
    		if (csp.CspKeyContainerInfo.HardwareDevice)
    			Console.WriteLine("hardware");
    		Console.WriteLine(cert.ToString());
    	}
    	else
    	{
    		throw new Exception("No private key assigned to this certificate");
    	}
    
    	// Hash the data
    	SHA1Managed sha1 = new SHA1Managed();
    	byte[] hash = sha1.ComputeHash(inData);
    
    	// Sign the hash
    	return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
    }
