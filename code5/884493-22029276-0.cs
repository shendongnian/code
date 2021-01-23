    using System;
    using NodaTime;
    using NodaTime.TimeZones;
    
    namespace NodaDSTDebug
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			IDateTimeZoneProvider timeZoneProvider = DateTimeZoneProviders.Bcl;
    			// get the system EST and MST time zone info structures
    			DateTimeZone tzEastern = timeZoneProvider["Eastern Standard Time"];
    			DateTimeZone tzMountain = timeZoneProvider["Mountain Standard Time"];
    
    			// 11/2/2014 02:00 EST should be 11/2/2014 01:00 MDT
    			ZonedDateTime dateToTest;
    			dateToTest = new ZonedDateTime(new LocalDateTime(2014, 11, 2, 2, 0, 0), tzEastern, Offset.FromHours(-5));
    			ShowConversion(dateToTest, tzMountain);
    			// 11/2/2014 03:00 EST should be 11/2/2014 01:00 MST
    			dateToTest = new ZonedDateTime(new LocalDateTime(2014, 11, 2, 3, 0, 0), tzEastern, Offset.FromHours(-5));
    			ShowConversion(dateToTest, tzMountain);
    		}
    
    		/// <summary>
    		/// Convert Eastern Time into Mountain Time
    		/// </summary>
    		/// <param name="dateToTest">Eastern Time</param>
    		/// <param name="tzMountain">Mountain TimeZone</param>
    		private static void ShowConversion(ZonedDateTime dateToTest, DateTimeZone tzMountain)
    		{
    			ZonedDateTime convertedTime = dateToTest.WithZone(tzMountain);
    			// for some reason the 'x' format pattern is not working, so they are ginned up as constants
    			// 'x' is printing the full timezone name e.g. "Eastern Standard Time"
    			Console.WriteLine("{0:MM/dd/yyyy HH:mm x} {1} =>  {2:MM/dd/yyyy HH:mm x} {3}",
    				dateToTest, IsDaylightSavingsTime(dateToTest) ? "EDT" : "EST",
    				convertedTime, IsDaylightSavingsTime(convertedTime) ? "MDT" : "MST");
    		}
    
    		// From http://stackoverflow.com/questions/15211052/what-is-the-system-timezoneinfo-isdaylightsavingtime-equivalent-in-nodatime
    		// Thanks to Matt Johnson
    		public static bool IsDaylightSavingsTime(ZonedDateTime zonedDateTime)
    		{
    			Instant instant = zonedDateTime.ToInstant();
    			ZoneInterval zoneInterval = zonedDateTime.Zone.GetZoneInterval(instant);
    			return zoneInterval.Savings != Offset.Zero;
    		}
    	}
    }
