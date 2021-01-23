    private SecureMimeContext CreateSecureMimeContext(string certificateFilename, string certificatePassword)
    {
        var secureMimeContext = new WindowsSecureMimeContext();
        var certificate = new X509Certificate2(certificateFilename,
                                               certificatePassword);
        var bouncyX509Certificate = Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(certificate);
        secureMimeContext.Import(bouncyX509Certificate);
        return secureMimeContext;
    }
