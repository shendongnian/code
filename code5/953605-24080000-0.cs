    var result = service.Events.List("primary").Execute();
        private async Task<UserCredential> GetCredential()
        {
            UserCredential credential = null;
            try
            {
                using(var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { CalendarService.Scope.Calendar },
                        "user", CancellationToken.None, new FileDataStore(""));
                }
            }
            catch (IOException ioe)
            {
                Debug.WriteLine("IOException" + ioe.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex);
            }
            return credential;
        }
        private CalendarService GetCalenderService(UserCredential credential)
        {
            CalendarService service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Calendar Sample"
                });
            return service;
        }
        private Events GetEvent(string CalendarId)
        {
            var query = this.Service.Events.List(CalendarId);
            query.ShowDeleted = false;
            query.SingleEvents = true;
            return query.Execute();
        }
