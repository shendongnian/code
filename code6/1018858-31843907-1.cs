        public async Task<ActionResult> GoogleCalendarAsync(CancellationToken cancellationToken)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
                AuthorizeAsync(cancellationToken);
            if (result.Credential != null)
            {
                //var ttt = await result.Credential.RevokeTokenAsync(cancellationToken);
                //bool x = await result.Credential.RefreshTokenAsync(cancellationToken);
                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "GoogleApplication",
                });
                var t = service.Calendars;
                var tt = service.CalendarList.List();
                // Define parameters of request.
                EventsResource.ListRequest request = service.Events.List("primary");
                request.TimeMin = DateTime.Now;
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
                // List events.
                Events events = request.Execute();
                Debug.WriteLine("Upcoming events:");
                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {
                        string when = eventItem.Start.DateTime.ToString();
                        if (String.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date;
                        }
                        Debug.WriteLine("{0} ({1})", eventItem.Summary, when);
                    }
                }
                else
                {
                    Debug.WriteLine("No upcoming events found.");
                }
                //Event myEvent = new Event
                //{
                //    Summary = "Appointment",
                //    Location = "Somewhere",
                //    Start = new EventDateTime()
                //        {
                //            DateTime = new DateTime(2014, 6, 2, 10, 0, 0),
                //            TimeZone = "America/Los_Angeles"
                //        },
                //    End = new EventDateTime()
                //        {
                //            DateTime = new DateTime(2014, 6, 2, 10, 30, 0),
                //            TimeZone = "America/Los_Angeles"
                //        },
                //    Recurrence = new String[] {
                //        "RRULE:FREQ=WEEKLY;BYDAY=MO"
                //        },
                //    Attendees = new List<EventAttendee>()
                //        {
                //        new EventAttendee() { Email = "johndoe@gmail.com" }
                //        }
                //};
                //Event recurringEvent = service.Events.Insert(myEvent, "primary").Execute();
                return View();
            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
        }
