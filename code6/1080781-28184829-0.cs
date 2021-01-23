    // Import the signed certificate
    X509Certificate signedX509Cert = new X509CertificateParser ().ReadCertificate (Encoding.UTF8.GetBytes (certSigned));
    X509CertificateEntry certEntry = new X509CertificateEntry (signedX509Cert);
    
    // Import the CA certificate
    X509Certificate signedX509CaCert = new X509CertificateParser ().ReadCertificate (Encoding.UTF8.GetBytes (certCA ));
    X509CertificateEntry certCaEntry = new X509CertificateEntry (signedX509CaCert);
    
    // Prepare the pkcs12 certificate store
    Pkcs12Store store = new Pkcs12StoreBuilder ().Build ();
    
    // Bundle together the private key, signed certificate and CA
    store.SetKeyEntry (signedX509Cert.SubjectDN.ToString () + "_key", new AsymmetricKeyEntry (keyPair.Private), new X509CertificateEntry[] {
    	certEntry,
    	certCaEntry
    });
    
    // Finally save the bundle as a PFX file
    using (var filestream = new FileStream (@"CertBundle.pfx", FileMode.Create, FileAccess.ReadWrite)) {
    	store.Save (filestream, "password".ToCharArray (), new SecureRandom ());
    }
