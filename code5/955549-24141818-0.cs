    X509Store store = new X509Store(StoreLocation.LocalMachine);
    X509Certificate2Collection col = default(X509Certificate2Collection);
    try {    
        col = store.Certificates.Find(X509FindType.FindBySubjectName, "MyCertName", false);
    }
    catch {}
    if(col == default(X509Certificate2Collection)) {
        // cert isn't there
    }
