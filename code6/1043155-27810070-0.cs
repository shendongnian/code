     ServiceAccountCredential sac = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmail)
                {
                    Scopes = scopes
                }.FromCertificate(certificate));
     var cts = new CancellationToken();
     var response = sac.RequestAccessTokenAsync(cts).Result;
