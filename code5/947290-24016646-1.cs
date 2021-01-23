            string mymail = googleauth.GetUsersEmail(ExchangeCodeWithAccessAndRefreshToken().Access_Token);
            string path = "d:\\c6b82065f26fbb0-privatekey.p12";
            X509Certificate2 certificate = new X509Certificate2(
                path,
                "notasecret", X509KeyStorageFlags.Exportable);
            ServiceAccountCredential credential = new ServiceAccountCredential(
              new ServiceAccountCredential.Initializer("876131792-v824u6drpss@developer.gserviceaccount.com")
              {
                  User = mymail,
                  Scopes = new[] { PlusService.Scope.UserinfoEmail, PlusService.Scope.UserinfoProfile, PlusService.Scope.PlusMe }
              }.FromCertificate(certificate));
            PlusService plus = new PlusService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "myapp"
            });
            Person profile = plus.People.Get("me").Execute();
            string email = profile.Emails[0].Value;
