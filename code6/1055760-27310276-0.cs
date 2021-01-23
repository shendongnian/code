    if (verify.Build(new X509Certificate2(certificate)))
    {
        return verify.ChainElements[verify.ChainElements.Count - 1]
            .Certificate.Thumbprint == cacert.thumbprint; // success?
    }
    return false;
