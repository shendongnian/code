    chain.ChainPolicy = new X509ChainPolicy()
    {
    	RevocationMode = X509RevocationMode.NoCheck,
    	VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid,
    	UrlRetrievalTimeout = new TimeSpan(0, 1, 0)
    };
