     private static void GetSuggestedMeetingTimes(ExchangeService service)
        {
            // Create a list of attendees.
            List<AttendeeInfo> attendees = new List<AttendeeInfo>();
            attendees.Add(new AttendeeInfo()
            {
                SmtpAddress = "shomaail@kfupm.edu.sa",
                AttendeeType = MeetingAttendeeType.Required,
                ExcludeConflicts = false
            });
            attendees.Add(new AttendeeInfo()
            {                
                SmtpAddress = "vrr@kfupm.edu.sa",
                AttendeeType = MeetingAttendeeType.Required
            });
            AvailabilityOptions meetingOptions = new AvailabilityOptions();
            meetingOptions.MeetingDuration = 30;
            meetingOptions.MaximumNonWorkHoursSuggestionsPerDay = 0;
            meetingOptions.GoodSuggestionThreshold = 49;
            meetingOptions.MinimumSuggestionQuality = SuggestionQuality.Excellent;
            meetingOptions.DetailedSuggestionsWindow = new TimeWindow(DateTime.Now, DateTime.Now.AddDays(2));
            meetingOptions.MaximumSuggestionsPerDay = 48;
            // Return a set of of suggested meeting times. 
            GetUserAvailabilityResults results = service.GetUserAvailability(attendees,
                                                                                 new TimeWindow(DateTime.Now, DateTime.Now.AddDays(2)),
                                                                                     AvailabilityData.FreeBusyAndSuggestions,
                                                                                     meetingOptions); 
          //  Console.WriteLine(results.AttendeesAvailability[0].WorkingHours.EndTime); 
            // Display available meeting times.
            Console.WriteLine("Availability for {0} and {1}", attendees[0].SmtpAddress, attendees[1].SmtpAddress);
            Console.WriteLine();
            foreach (AttendeeAvailability aa in results.AttendeesAvailability)
            {
                Console.WriteLine("=============================================");
                Console.WriteLine(aa.Result.ToString());
                Console.WriteLine(aa.ViewType.ToString());
                Console.WriteLine(aa.CalendarEvents.Count);
                Console.WriteLine(aa.WorkingHours.StartTime);
                Console.WriteLine(aa.WorkingHours.EndTime);
                Console.WriteLine(aa.WorkingHours.DaysOfTheWeek.Count);
                Console.WriteLine(aa.WorkingHours.DaysOfTheWeek[0]);
                Console.WriteLine(aa.WorkingHours.DaysOfTheWeek[aa.WorkingHours.DaysOfTheWeek.Count-1]);
                foreach (DayOfTheWeek dow in aa.WorkingHours.DaysOfTheWeek)
                {
                    Console.WriteLine(dow);
                }
            }
            foreach (Suggestion suggestion in results.Suggestions)
            {
                Console.WriteLine(suggestion.Date);
                Console.WriteLine();
                foreach (TimeSuggestion timeSuggestion in suggestion.TimeSuggestions)
                {
                    Console.WriteLine("Suggested meeting time:" + timeSuggestion.MeetingTime);
                    Console.WriteLine();
                }
            }
        }
