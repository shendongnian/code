                        serviceAccountEmail = primaryLink.serviceEmailAddress;
                        certificate = new X509Certificate2(AppDomain.CurrentDomain.BaseDirectory + "certs//" + primaryLink.certificate, primaryLink.certificatePassword, X509KeyStorageFlags.Exportable);
                        try
                        {
                            credential = new ServiceAccountCredential(
                            new ServiceAccountCredential.Initializer(serviceAccountEmail)
                            {
                                User = z.us.emailAccount,
                                Scopes = new[] { "https://www.googleapis.com/auth/userinfo.email", "https://www.googleapis.com/auth/userinfo.profile", "https://mail.google.com/" }
                            }.FromCertificate(certificate));
                            if (credential.RequestAccessTokenAsync(CancellationToken.None).Result)
                            {
                                gs = new GmailService(
                                new Google.Apis.Services.BaseClientService.Initializer()
                                {
                                    ApplicationName = "Example",
                                    HttpClientInitializer = credential
                                });
                            }
                            else
                            {
                                throw new Exception("gmail authentication Error.");
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        ListMessagesResponse respM = reqM.Execute();
                        if (respM.Messages != null)
                        {   
                             foreach (Message m in respM.Messages)
                             {}
                        } 
