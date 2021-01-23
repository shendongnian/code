    using System;
    
    using Google.Apis.Calendar.v3;
    using Google.Apis.Calendar.v3.Data;
    // for BaseClientService.Initializer
    using Google.Apis.Services;
    // provides ServiceAccountCredential
    using Google.Apis.Auth.OAuth2; 
    // read in cert
    using System.Security.Cryptography.X509Certificates;
    
    
    namespace LunaIntraDBCalTest
    {
    	public class Program
    	{
    		public static string calendarname = "xxxx@gmail.com"; //address is default calendar
    		public static string serviceAccountEmail = "yyyy@developer.gserviceaccount.com";
    
    		public static CalendarService getCalendarService(){
    
    
    
    			// certificate downloaded after creating service account access at could.google.com
    			var certificate = new X509Certificate2(@"key.p12", "notasecret", X509KeyStorageFlags.Exportable);
    
    			// autheticate
    			ServiceAccountCredential credential = new ServiceAccountCredential(
    				new ServiceAccountCredential.Initializer(serviceAccountEmail)
    				{
    					Scopes = new[] { CalendarService.Scope.Calendar }
    				}.FromCertificate(certificate));
    
    			// Create the service.
    			var service = new CalendarService(new BaseClientService.Initializer()
    				{
    					HttpClientInitializer = credential,
    					ApplicationName = "LunaIntraDB",
    				});
    
    			return service;
    		}
    
    		// create event object that will later be inserted
    		public static Event createEvent(string Summary, string Location, string Description, DateTime ApptDateTime, double duration ){
    			// create an event
    			Event entry= new Event
    			{
    				Summary = Summary,
    				Location = Location,
    				Description = Description,
    				Start = new EventDateTime { DateTime = ApptDateTime },
    				End = new EventDateTime { DateTime = ApptDateTime.AddHours(duration) },
    			};
    
    			return entry;
    		}
    
    		// capture event ID after inserting
    		public static string insertEvent(Event entry){
    			var service = getCalendarService ();
    			EventsResource.InsertRequest insert = service.Events.Insert (entry, calendarname);
    			// TODO: try catch here; will be throw exception if bad datetime
    			return insert.Execute().Id;
    		}
    
    		public static void deleteEvent(string id){
    			// TODO CATCH IF NOT FOUND
    			// to have access to this calendar, serviceAccountEmail needed permission set by ownner in google calendar
    			//Calendar cal1 = service.Calendars.Get (calnedarname).Execute();
    			var service = getCalendarService ();
    			service.Events.Delete (calendarname, id).Execute ();
    		}
    
    		public static void Main(string[] args)
    		{
    
    			// create event
    			var entry = createEvent ("TEST", "here", "this is a test", DateTime.Now, 1.5);
    
    			string id = insertEvent (entry);
    			Console.WriteLine("Run to your calendar to see that this event was created... (any key after checking)");
    			Console.ReadKey();
    
    			deleteEvent (id);
    			Console.WriteLine("Should now be deleted!... (any key to close)");
    			Console.ReadKey();
    		}
    	}
    }
