    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Calendar.v3;
    using Google.Apis.Calendar.v3.Data;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using System;
    using System.IO;
    using System.Threading;
    
    namespace GoogleCalendarAPI
    
    {
        class Program
        {
            // If modifying these scopes, delete your previously saved credentials
            // at ~/.credentials/calendar-dotnet-quickstart.json
            static string[] Scopes = { CalendarService.Scope.CalendarReadonly,
                                       CalendarService.Scope.CalendarEvents,
                                        CalendarService.Scope.Calendar};
    
            static string ApplicationName = System.AppDomain.CurrentDomain.FriendlyName;
            static void Main(string[] args)
            {
                CalendarEvent oCalEvent = new CalendarEvent();
                oCalEvent.Summary = "Hello Calendar";
                oCalEvent.Description = "Just another day";
                oCalEvent.Location = "Earth";
                oCalEvent.Start = DateTime.Now.AddDays(31);
                oCalEvent.Stop = DateTime.Now.AddDays(31);
                AddCalendarEvent(oCalEvent);
                ListUpComing();
    
                Console.Read();
            }
    
            static void ListUpComing()
            {
                UserCredential credential;
    
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "admin",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
    
                // Create Google Calendar API service.
                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
    
                // Define parameters of request.
                EventsResource.ListRequest request = service.Events.List("primary");
                request.TimeMin = DateTime.Now;
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
    
                // List events.
                Events events = request.Execute();
                Console.WriteLine("Upcoming events:");
                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {
                        string when = eventItem.Start.DateTime.ToString();
                        if (String.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date;
                        }
                        Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                    }
                }
                else
                {
                    Console.WriteLine("No upcoming events found.");
                }
                Console.Read();
            }
    
            static void AddCalendarEvent(CalendarEvent oCalEvent)
            {
                UserCredential credential;
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "admin",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
    
                var service = new CalendarService(new BaseClientService.Initializer()   
                { HttpClientInitializer = credential, ApplicationName = ApplicationName, });              // Create Google Calendar API service.
    
                Event evntNew = new Event();
                evntNew.Summary = oCalEvent.Summary;
                evntNew.Location = oCalEvent.Location;
                evntNew.Description = oCalEvent.Description;
                evntNew.Start = oCalEvent.Start.ToEventDateTime();
                evntNew.End = oCalEvent.Stop.ToEventDateTime();
                EventsResource.InsertRequest insertRequest = service.Events.Insert(evntNew, "primary");
                insertRequest.Execute();
            }
        }
    }
    
    public static class Extensions
    {
        public static EventDateTime ToEventDateTime(this DateTime dDateTime)
        {
            EventDateTime edtDateTime = new EventDateTime();
            edtDateTime.DateTime = DateTime.ParseExact(dDateTime.ToString("MM/dd/yyyy HH:mm"), "MM/dd/yyyy HH:mm", null);
            return edtDateTime;
        }
    
    }
    public class CalendarEvent
    {
        public CalendarEvent() { }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
    }
    
    // END
