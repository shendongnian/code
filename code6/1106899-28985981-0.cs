    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
	var signer = X509Certificate.CreateFromSignedFile("[path to the file]");
	var cert = new X509Certificate2(signer);
	var certChain = new X509Chain();
	certChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
	certChain.ChainPolicy.RevocationMode = CheckRevocOffline ? X509RevocationMode.Offline : X509RevocationMode.Online;
	certChain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
	certChain.ChainPolicy.VerificationFlags = VerificationFlags;
	var certChainIsValid = certChain.Build(cert);
	if (!certChainIsValid)
	{
		//file is likely to be self signed, revoked or expired
	}
	var subjectName = cert.SubjectName.Name;
