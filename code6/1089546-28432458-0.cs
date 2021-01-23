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
    
                    string[] scopes = new string[] { DriveService.Scope.Drive};     // View analytics data            
    
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
                            ApplicationName = "Drive API Sample",
                        });
                        return service;
                    }
                    catch (Exception ex)
                    {
    
                        Console.WriteLine(ex.InnerException);
                        return null;
    
                    }
                }
