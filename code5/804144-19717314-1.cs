    X509Store Store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
    Store.Open(OpenFlags.ReadOnly);
    X509Certificate2Collection CertColl = Store.Certificates.Find(X509FindType.FindByIssuerName, "Microsoft",true);
    foreach (X509Certificate2 Cert in CertColl)
        Console.WriteLine("Cert: " + Cert.IssuerName.Name);
