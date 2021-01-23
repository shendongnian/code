    public static string ApplicationName = "ApplicationName";
            public static string ClientId = "ClientId";
            public static string ClientSecret = "ClientSecret";
    
            public static ClientSecrets GoogleClientSecrets = new ClientSecrets()
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret
            };
    
            public static string[] Scopes =
            {
                                    CalendarService.Scope.Calendar,
                                    CalendarService.Scope.CalendarReadonly
                                };
    
            public static UserCredential GetUserCredential(out string error)
            {
                UserCredential credential = null;
                error = string.Empty;
    
                try
                {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = ClientId,
                        ClientSecret = ClientSecret
                    },
                    Scopes,
                    Environment.UserName,
                    CancellationToken.None,
                    null).Result;
                }
                catch (Exception ex)
                {
                    credential = null;
                    error = "Failed to UserCredential Initialization: " + ex.ToString();
                }
    
                return credential;
            }
    
            public static IAuthorizationCodeFlow GoogleAuthorizationCodeFlow(out string error)
            {
                IAuthorizationCodeFlow flow = null;
                error = string.Empty;
    
                try
                {
                    flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                    {
                        ClientSecrets = GoogleClientSecrets,
                        Scopes = Scopes
                    });
                }
                catch (Exception ex)
                {
                    flow = null;
                    error = "Failed to AuthorizationCodeFlow Initialization: " + ex.ToString();
                }
    
                return flow;
            }
    
            public static UserCredential GetGoogleUserCredentialByRefreshToken(string refreshToken, out string error)
            {
                TokenResponse respnseToken = null;
                UserCredential credential = null;
                string flowError;
                error = string.Empty;
                try
                {
                    // Get a new IAuthorizationCodeFlow instance
                    IAuthorizationCodeFlow flow = GoogleAuthorizationCodeFlow(out flowError);
    
                    respnseToken = new TokenResponse() { RefreshToken = refreshToken };
    
                    // Get a new Credential instance                
                    if ((flow != null && string.IsNullOrWhiteSpace(flowError)) && respnseToken != null)
                    {
                        credential = new UserCredential(flow, "user", respnseToken);
                    }
    
                    // Get a new Token instance
                    if (credential != null)
                    {
                        bool success = credential.RefreshTokenAsync(CancellationToken.None).Result;
                    }
    
                    // Set the new Token instance
                    if (credential.Token != null)
                    {
                        string newRefreshToken = credential.Token.RefreshToken);
                    }
                }
                catch (Exception ex)
                {
                    credential = null;
                    error = "UserCredential failed: " + ex.ToString();
                }
                return credential;
            }
    
            public static CalendarService GetCalendarService(string refreshToken, out string error)
            {
                CalendarService calendarService = null;
                string credentialError;
                error = string.Empty;
                try
                {
                    var credential = GetGoogleUserCredentialByRefreshToken(refreshToken, out credentialError);
                    if (credential != null && string.IsNullOrWhiteSpace(credentialError))
                    {
                        calendarService = new CalendarService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = ApplicationName
                        });
                    }
                }
                catch (Exception ex)
                {
                    calendarService = null;
                    error = "Calendar service failed: " + ex.ToString();
                }
                return calendarService;
            }
    
            public static string AddCalenderEvents(string refreshToken, string emailAddress, string summary, DateTime? start, DateTime? end, out string error)
            {
                string eventId = string.Empty;
                error = string.Empty;
                string serviceError;
    
                try
                {
                    var calendarService = GetCalendarService(refreshToken, out serviceError);
    
                    if (calendarService != null && string.IsNullOrWhiteSpace(serviceError))
                    {
                        var list = calendarService.CalendarList.List().Execute();
                        var calendar = list.Items.SingleOrDefault(c => c.Summary == emailAddress);
                        if (calendar != null)
                        {
                            Google.Apis.Calendar.v3.Data.Event calenderEvent = new Google.Apis.Calendar.v3.Data.Event();
    
                            calenderEvent.Summary = summary;
                            //calenderEvent.Description = summary;
                            //calenderEvent.Location = summary;
                            calenderEvent.Start = new Google.Apis.Calendar.v3.Data.EventDateTime
                            {
                                //DateTime = new DateTime(2018, 1, 20, 19, 00, 0)
                                DateTime = start//,
                                //TimeZone = "Europe/Istanbul"
                            };
                            calenderEvent.End = new Google.Apis.Calendar.v3.Data.EventDateTime
                            {
                                //DateTime = new DateTime(2018, 4, 30, 23, 59, 0)
                                DateTime = start.Value.AddHours(12)//,
                                //TimeZone = "Europe/Istanbul"
                            };
                            calenderEvent.Recurrence = new List<string>();
    
                            //Set Remainder
                            calenderEvent.Reminders = new Google.Apis.Calendar.v3.Data.Event.RemindersData()
                            {
                                UseDefault = false,
                                Overrides = new Google.Apis.Calendar.v3.Data.EventReminder[]
                                {
                                                        new Google.Apis.Calendar.v3.Data.EventReminder() { Method = "email", Minutes = 24 * 60 },
                                                        new Google.Apis.Calendar.v3.Data.EventReminder() { Method = "popup", Minutes = 24 * 60 }
                                }
                            };
    
                            #region Attendees
                            //Set Attendees
                            calenderEvent.Attendees = new Google.Apis.Calendar.v3.Data.EventAttendee[] {
                                                    new Google.Apis.Calendar.v3.Data.EventAttendee() { Email = "kaptan.cse@gmail.com" },
                                                    new Google.Apis.Calendar.v3.Data.EventAttendee() { Email = emailAddress }
                                                };
                            #endregion
    
                            var newEventRequest = calendarService.Events.Insert(calenderEvent, calendar.Id);
                            newEventRequest.SendNotifications = true;
                            var eventResult = newEventRequest.Execute();
                            eventId = eventResult.Id;
                        }
                    }
                }
                catch (Exception ex)
                {
                    eventId = string.Empty;
                    error = ex.Message;
                }
                return eventId;
            }
            public static Google.Apis.Calendar.v3.Data.Event UpdateCalenderEvents(string refreshToken, string emailAddress, string summary, DateTime? start, DateTime? end, string eventId, out string error)
            {
                Google.Apis.Calendar.v3.Data.Event eventResult = null;
                error = string.Empty;
                string serviceError;
                try
                {
                    var calendarService = GetCalendarService(refreshToken, out serviceError);
                    if (calendarService != null)
                    {
                        var list = calendarService.CalendarList.List().Execute();
                        var calendar = list.Items.SingleOrDefault(c => c.Summary == emailAddress);
                        if (calendar != null)
                        {
                            // Define parameters of request
                            EventsResource.ListRequest request = calendarService.Events.List("primary");
                            request.TimeMin = DateTime.Now;
                            request.ShowDeleted = false;
                            request.SingleEvents = true;
                            request.MaxResults = 10;
                            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
    
                            // Get selected event
                            Google.Apis.Calendar.v3.Data.Events events = request.Execute();
                            var selectedEvent = events.Items.FirstOrDefault(c => c.Id == eventId);
                            if (selectedEvent != null)
                            {
                                selectedEvent.Summary = summary;
                                selectedEvent.Start = new Google.Apis.Calendar.v3.Data.EventDateTime
                                {
                                    DateTime = start
                                };
                                selectedEvent.End = new Google.Apis.Calendar.v3.Data.EventDateTime
                                {
                                    DateTime = start.Value.AddHours(12)
                                };
                                selectedEvent.Recurrence = new List<string>();
    
                                // Set Remainder
                                selectedEvent.Reminders = new Google.Apis.Calendar.v3.Data.Event.RemindersData()
                                {
                                    UseDefault = false,
                                    Overrides = new Google.Apis.Calendar.v3.Data.EventReminder[]
                                    {
                                                            new Google.Apis.Calendar.v3.Data.EventReminder() { Method = "email", Minutes = 24 * 60 },
                                                            new Google.Apis.Calendar.v3.Data.EventReminder() { Method = "popup", Minutes = 24 * 60 }
                                    }
                                };
    
                                // Set Attendees
                                selectedEvent.Attendees = new Google.Apis.Calendar.v3.Data.EventAttendee[]
                                {
                                                        new Google.Apis.Calendar.v3.Data.EventAttendee() { Email = "kaptan.cse@gmail.com" },
                                                        new Google.Apis.Calendar.v3.Data.EventAttendee() { Email = emailAddress }
                                };
                            }
    
                            var updateEventRequest = calendarService.Events.Update(selectedEvent, calendar.Id, eventId);
                            updateEventRequest.SendNotifications = true;
                            eventResult = updateEventRequest.Execute();
                        }
                    }
                }
                catch (Exception ex)
                {
                    eventResult = null;
                    error = ex.ToString();
                }
                return eventResult;
            }
            public static void DeletCalendarEvents(string refreshToken, string emailAddress, string eventId, out string error)
            {
                string result = string.Empty;
                error = string.Empty;
                string serviceError;
                try
                {
                    var calendarService = GetCalendarService(refreshToken, out serviceError);
                    if (calendarService != null)
                    {
                        var list = calendarService.CalendarList.List().Execute();
                        var calendar = list.Items.FirstOrDefault(c => c.Summary == emailAddress);
                        if (calendar != null)
                        {
                            // Define parameters of request
                            EventsResource.ListRequest request = calendarService.Events.List("primary");
                            request.TimeMin = DateTime.Now;
                            request.ShowDeleted = false;
                            request.SingleEvents = true;
                            request.MaxResults = 10;
                            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
    
                            // Get selected event
                            Google.Apis.Calendar.v3.Data.Events events = request.Execute();
                            var selectedEvent = events.Items.FirstOrDefault(c => c.Id == eventId);
                            if (selectedEvent != null)
                            {
                                var deleteEventRequest = calendarService.Events.Delete(calendar.Id, eventId);
                                deleteEventRequest.SendNotifications = true;
                                deleteEventRequest.Execute();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = string.Empty;
                    error = ex.ToString();
                }
            }
    
            public static void Run()
            {
                string refreshToken = string.Empty;
                string credentialError;
                var credential = GetUserCredential(out credentialError);
                if (credential != null && string.IsNullOrWhiteSpace(credentialError))
                {
                    //Save RefreshToken into Database 
                    refreshToken = credential.Token.RefreshToken;
                }
    
                string addEventError;
                string calendarEventId = string.Empty;
    
                calendarEventId = AddCalenderEvents(refreshToken, "kaptan.cse@gmail.com", "My Calendar Event", DateTime.Now, DateTime.Now.Value.AddHours(12), out addEventError);
    
                string updateEventError;
                if (!string.IsNullOrEmpty(calendarEventId))
                {
                    UpdateCalenderEvents(refreshToken, "kaptan.cse@gmail.com", "Modified Calendar Event ", DateTime.Now, DateTime.Now.Value.AddDays(1), calendarEventId, out updateEventError);
                }
    
                string deleteEventError;
                if (!string.IsNullOrEmpty(calendarEventId))
                {
                    DeletCalendarEvents(refreshToken, "kaptan.cse@gmail.com", calendarEventId, out deleteEventError);
                }
            }
