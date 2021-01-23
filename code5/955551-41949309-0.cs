    X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadOnly);
    var certificates = store.Certificates.Find(
        X509FindType.FindBySubjectName, 
        "subjectName", 
        false);
    if (certificates != null && certificates.Count > 0)
    {
       Console.WriteLine("Certificate already exists");
    }
