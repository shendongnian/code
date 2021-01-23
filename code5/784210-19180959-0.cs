    public static void RemoveFromStorage(StoreName storeName, IEnumerable<CertInfo>    certificates)
    {
        var store = new X509Store(storeName, StoreLocation.CurrentUser);
        store.Open(OpenFlags.MaxAllowed | OpenFlags.IncludeArchived | OpenFlags.ReadWrite);
        foreach (var cert in certificates)
        {
            var toRemove = store.Certificates.Find(X509FindType.FindByThumbprint, cert.Thumbprint, false);
            store.Certificates.Remove(toRemove[0]);
        }
        store.Close();
    }
