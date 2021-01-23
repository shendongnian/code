    // Create the PKCS12 store
    Pkcs12Store store = new Pkcs12Store();
    // Add a Certificate entry
    string certCn = cert.SubjectDN.GetValues(X509Name.CN).OfType<string>().Single();
    X509CertificateEntry certEntry = new X509CertificateEntry(cert);
    store.SetCertificateEntry(certCn, certEntry); // use DN as the Alias.
    // Add a key entry & cert chain (if applicable)
    AsymmetricKeyEntry keyEntry = new AsymmetricKeyEntry(kp.Private);
    X509CertificateEntry[] certChain;
    if (_issuerCert != null)
    {
        X509CertificateEntry issuerCertEntry = new X509CertificateEntry(_issuerCert);
        certChain = new X509CertificateEntry[] { certEntry, issuerCertEntry};
    }
    else
    {
        certChain = new X509CertificateEntry[] { certEntry };
    }
    store.SetKeyEntry(certCn, keyEntry, certChain); // Set the friendly name along with the generated certs key and its chain
    // Write the p12 file to disk
    FileInfo p12File = new FileInfo(pathToP12File);
    Directory.CreateDirectory(p12File.DirectoryName);
    using (FileStream filestream = new FileStream(pathToP12File, FileMode.Create, FileAccess.ReadWrite))
    {
         store.Save(filestream, password.ToCharArray(), new SecureRandom());
    }
