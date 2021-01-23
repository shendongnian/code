        private static String GetOAuthCredentialViaP12Key()
        {
            const string serviceAccountEmail = SERVICE_ACCOUNT_EMAIL;
            var certificate = new X509Certificate2(SERVICE_ACCOUNT_PKCS12_FILE_PATH, "notasecret", X509KeyStorageFlags.Exportable);
            var scope = DriveService.Scope.Drive + " https://spreadsheets.google.com/feeds";
            var credential = new ServiceAccountCredential( new ServiceAccountCredential.Initializer(serviceAccountEmail)
                                                           {
                                                                Scopes  = new[] { scope }
                                                           }.FromCertificate(certificate) );
            if (credential.RequestAccessTokenAsync(CancellationToken.None).Result == false)
            {
                return null;
            }
            return credential.Token.AccessToken;
        }
