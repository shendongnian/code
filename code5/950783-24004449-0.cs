            X509Certificate2 certificate = new X509Certificate2(AppDomain.CurrentDomain.BaseDirectory + "certs//" + certificateFile, certificatePassword, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
            ServiceAccountCredential credential = new ServiceAccountCredential(
            new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = new[] { Google.Apis.Calendar.v3.CalendarService.Scope.Calendar },
                User = user
            }.FromCertificate(certificate));
            Google.Apis.Calendar.v3.CalendarService service = new Google.Apis.Calendar.v3.CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "AppX",
            });
                Google.Apis.Calendar.v3.Data.Event evv = service.Events.Get(user, "6ebr4dp452m453n468movuntag").Execute();
                EventsResource.UpdateRequest ur = new EventsResource.UpdateRequest(service, evv, user, evv.Id);
                ur.Execute();
           
