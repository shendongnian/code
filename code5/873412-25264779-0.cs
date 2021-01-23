     String serviceAccountEmail = "......@developer.gserviceaccount.com";
                    X509Certificate2 certificate = new X509Certificate2(@"C:\key.p12", "notasecret", X509KeyStorageFlags.Exportable);
                    ServiceAccountCredential credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
                    {
                        Scopes = new[]
                        {
                            DirectoryService.Scope.AdminDirectoryUser
                        },
                        User = "admin@domain.com"
                    }.FromCertificate(certificate));
    
                    var ser = new DirectoryService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Get it to work",
                    });
    
                    User newuserbody = new User();
                    UserName newusername = new UserName();
                    newuserbody.PrimaryEmail = "jack@domain.com";
                    newusername.GivenName = "jack";
                    newusername.FamilyName = "black";
                    newuserbody.Name = newusername;
                    newuserbody.Password = "password";
    
                    User results = ser.Users.Insert(newuserbody).Execute();
