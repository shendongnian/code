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
