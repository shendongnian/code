    var certificate = 
        new X509Certificate2
        (HttpContext.Current.Server.MapPath("~/Certifications/" + certname), 
        "notasecret", 
        X509KeyStorageFlags.MachineKeySet |
        X509KeyStorageFlags.PersistKeySet | 
        X509KeyStorageFlags.Exportable);
    
    
    ServiceAccountCredential credential = new ServiceAccountCredential(
        new ServiceAccountCredential.Initializer(accemail)
        {
            Scopes = new[] { AnalyticsService.Scope.Analytics.ToLower() }
        }.FromCertificate(certificate));
    return credential;
