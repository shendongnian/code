    host.Credentials.ClientCertificate.Authentication.CertificateValidationMode 
            =X509CertificateValidationMode.Custom;
        
    host.Credentials.ClientCertificate.Authentication.CustomCertificateValidator =
            new IssuerNameCertValidator("CN=client.com");
