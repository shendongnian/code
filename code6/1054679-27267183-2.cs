    string[] scopes = new string[] {
            CalendarService.Scope.Calendar  ,  // Manage your calendars
            CalendarService.Scope.CalendarReadonly    // View your Calendars
                };
    
                try
                {
                    // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                        , scopes
                                                                        , userName
                                                                        , CancellationToken.None
                                                                        , new FileDataStore("Daimto.GoogleCalendar.Auth.Store")).Result;
    
    
    
                    CalendarService service = new CalendarService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Calendar API Sample",
                    });
                    return service;
                }
                catch (Exception ex)
                {
    
                    Console.WriteLine(ex.InnerException);
                    return null;
    
                }
