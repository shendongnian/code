    /// <summary>
            /// Authenticating to Google using a Service account
            /// Documentation: https://developers.google.com/accounts/docs/OAuth2#serviceaccount
            /// </summary>
            /// <param name="serviceAccountEmail">From Google Developer console https://console.developers.google.com</param>
            /// <param name="keyFilePath">Location of the Service account key file downloaded from Google Developer console https://console.developers.google.com</param>
            /// <returns></returns>
            public static DriveService AuthenticateServiceAccount(string serviceAccountEmail, string keyFilePath)
            {
    
                // check the file exists
                if (!File.Exists(keyFilePath))
                {
                    Console.WriteLine("An Error occurred - Key file does not exist");
                    return null;
                }
    
                //Google Drive scopes Documentation:   https://developers.google.com/drive/web/scopes
                string[] scopes = new string[] { DriveService.Scope.Drive,  // view and manage your files and documents
                                                 DriveService.Scope.DriveAppdata,  // view and manage its own configuration data
                                                 DriveService.Scope.DriveAppsReadonly,   // view your drive apps
                                                 DriveService.Scope.DriveFile,   // view and manage files created by this app
                                                 DriveService.Scope.DriveMetadataReadonly,   // view metadata for files
                                                 DriveService.Scope.DriveReadonly,   // view files and documents on your drive
                                                 DriveService.Scope.DriveScripts };  // modify your app scripts     
    
                var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
                try
                {
                    ServiceAccountCredential credential = new ServiceAccountCredential(
                        new ServiceAccountCredential.Initializer(serviceAccountEmail)
                       {
                           Scopes = scopes
                       }.FromCertificate(certificate));
    
                    // Create the service.
                    DriveService service = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Daimto Drive API Sample",
                    });
                    return service;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    return null;
    
                }
            }
        }
