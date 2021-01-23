	using CERTENROLLLib;
	using CERTCLILib;
	
	public string GenerateRequest(string Subject, StoreLocation Location)
	{
		//code originally came from: http://blogs.msdn.com/b/alejacma/archive/2008/09/05/how-to-create-a-certificate-request-with-certenroll-and-net-c.aspx
		//modified version of it is here: http://stackoverflow.com/questions/16755634/issue-generating-a-csr-in-windows-vista-cx509certificaterequestpkcs10
		//here is the standard for certificates: http://www.ietf.org/rfc/rfc3280.txt
		//the PKCS#10 certificate request (http://msdn.microsoft.com/en-us/library/windows/desktop/aa377505.aspx)
		CX509CertificateRequestPkcs10 objPkcs10 = new CX509CertificateRequestPkcs10();
		//assymetric private key that can be used for encryption (http://msdn.microsoft.com/en-us/library/windows/desktop/aa378921.aspx)
		CX509PrivateKey objPrivateKey = new CX509PrivateKey();
		//access to the general information about a cryptographic provider (http://msdn.microsoft.com/en-us/library/windows/desktop/aa375967.aspx)
		CCspInformation objCSP = new CCspInformation();
		//collection on cryptographic providers available: http://msdn.microsoft.com/en-us/library/windows/desktop/aa375967(v=vs.85).aspx
		CCspInformations objCSPs = new CCspInformations();
		CX500DistinguishedName objDN = new CX500DistinguishedName();
		//top level object that enables installing a certificate response http://msdn.microsoft.com/en-us/library/windows/desktop/aa377809.aspx
		CX509Enrollment objEnroll = new CX509Enrollment();
		CObjectIds objObjectIds = new CObjectIds();
		CObjectId objObjectId = new CObjectId();
		CObjectId objObjectId2 = new CObjectId();
		CX509ExtensionKeyUsage objExtensionKeyUsage = new CX509ExtensionKeyUsage();
		CX509ExtensionEnhancedKeyUsage objX509ExtensionEnhancedKeyUsage = new CX509ExtensionEnhancedKeyUsage();
		string csr_pem = null;
		//  Initialize the csp object using the desired Cryptograhic Service Provider (CSP)
		objCSPs.AddAvailableCsps();
		//Provide key container name, key length and key spec to the private key object
		objPrivateKey.ProviderName = providerName;
		objPrivateKey.Length = KeyLength;
		objPrivateKey.KeySpec = X509KeySpec.XCN_AT_KEYEXCHANGE; //Must flag as XCN_AT_KEYEXCHANGE to use this certificate for exchanging symmetric keys (needed for most SSL cipher suites)
		objPrivateKey.KeyUsage = X509PrivateKeyUsageFlags.XCN_NCRYPT_ALLOW_ALL_USAGES;                
		if (Location == StoreLocation.LocalMachine)
			objPrivateKey.MachineContext = true;
		else
			objPrivateKey.MachineContext = false; //must set this to true if installing to the local machine certificate store
		objPrivateKey.ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_EXPORT_FLAG;    //must set this if we want to be able to export it later. 
		objPrivateKey.CspInformations = objCSPs;
		//  Create the actual key pair
		objPrivateKey.Create();
		//  Initialize the PKCS#10 certificate request object based on the private key.
		//  Using the context, indicate that this is a user certificate request and don't
		//  provide a template name
		if (Location == StoreLocation.LocalMachine)
			objPkcs10.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextMachine, objPrivateKey, "");
		else
			objPkcs10.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextUser, objPrivateKey, "");
		//Set hash to sha256
		CObjectId hashobj = new CObjectId();
		hashobj.InitializeFromAlgorithmName(ObjectIdGroupId.XCN_CRYPT_HASH_ALG_OID_GROUP_ID, ObjectIdPublicKeyFlags.XCN_CRYPT_OID_INFO_PUBKEY_ANY, AlgorithmFlags.AlgorithmFlagsNone, "SHA256");
		objPkcs10.HashAlgorithm = hashobj;
		// Key Usage Extension -- we only need digital signature and key encipherment for TLS:
		//  NOTE: in openSSL, I didn't used to request any specific extensions. Instead, I let the CA add them
		objExtensionKeyUsage.InitializeEncode(
			CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_DIGITAL_SIGNATURE_KEY_USAGE |
			CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_KEY_ENCIPHERMENT_KEY_USAGE
		);
		objPkcs10.X509Extensions.Add((CX509Extension)objExtensionKeyUsage);
		// Enhanced Key Usage Extension
		objObjectId.InitializeFromValue("1.3.6.1.5.5.7.3.1"); // OID for Server Authentication usage (see this: http://stackoverflow.com/questions/17477279/client-authentication-1-3-6-1-5-5-7-3-2-oid-in-server-certificates)
		objObjectId2.InitializeFromValue("1.3.6.1.5.5.7.3.2"); // OID for Client Authentication usage (see this: http://stackoverflow.com/questions/17477279/client-authentication-1-3-6-1-5-5-7-3-2-oid-in-server-certificates)
		objObjectIds.Add(objObjectId);
		objObjectIds.Add(objObjectId2);
		objX509ExtensionEnhancedKeyUsage.InitializeEncode(objObjectIds);
		objPkcs10.X509Extensions.Add((CX509Extension)objX509ExtensionEnhancedKeyUsage);
		//  Encode the name in using the Distinguished Name object
		// see here: http://msdn.microsoft.com/en-us/library/windows/desktop/aa379394(v=vs.85).aspx		
		objDN.Encode(
			Subject,
			X500NameFlags.XCN_CERT_NAME_STR_SEMICOLON_FLAG
		); 
		// Assign the subject name by using the Distinguished Name object initialized above
		objPkcs10.Subject = objDN;
		//suppress extra attributes:
		objPkcs10.SuppressDefaults = true;
		// Create enrollment request
		objEnroll.InitializeFromRequest(objPkcs10);
		csr_pem = objEnroll.CreateRequest(
			EncodingType.XCN_CRYPT_STRING_BASE64
		);
		csr_pem = "-----BEGIN CERTIFICATE REQUEST-----\r\n" + csr_pem + "-----END CERTIFICATE REQUEST-----";
		return csr_pem;
	}
