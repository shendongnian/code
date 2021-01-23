    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
    X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindByThumbprint, CERTIFICATE_THUMB_PRINT, false);
    if (certificates.Count == 0)
    {
        // "Certificate not installed."
    }
    else
    {
        certificate = certificates[0];
    }
    store.Close();
