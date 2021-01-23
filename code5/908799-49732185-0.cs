    public static CalendarService GetService()
        {
            var Scopes = new string[] { CalendarService.Scope.Calendar };
            UserCredential credential;
            string filePath = Path.Combine("*YOUR DOWNLOADED JSON FILE LOCATION HERE*");
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                string credPath = "*WHERE YOU WILL STORE YOUR CREDENTIALS FILE*";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "*YOUR APPLICATION NAME HERE*",
            });
            return service;
        }
