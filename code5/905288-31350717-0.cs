    using Security.Cryptography.X509Certificates; // Get extension methods
    
    X509Certificate cert; // Populate from somewhere else...
    if (cert.HasCngKey())
    {
        var privateKey = cert.GetCngPrivateKey();
    }
    else
    {
        var privateKey = cert.PrivateKey;
    }
