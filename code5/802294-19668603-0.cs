        //This code block is designed to schedule a timer for 5:35pm Eastern Time, regardless of whether is is Daylight Savings (EDT, UTC-4) or not (EST, UTC-5). 
        //  When understanding this code it is important to remember that a DateTime in UTC time represents an ABSOLUTE point in time. Any UTC time can only occur once. 
        //  A date time measured in local time (here we force Eastern Standard) is NOT ABSOLUTE. The same local time can occur twice (2am Nov 3nd 2013 for example)
        //Gets Eastern Timezone to be used in conversions
        TimeZoneInfo easternTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        //Grabs the current time (UTC) 
        DateTime utcNowDateTime = DateTime.Now.ToUniversalTime();
        //Gets current time in Eastern Time (could be UTC-4 or -5 depending on time of year)
        DateTime easternNowDateTime = TimeZoneInfo.ConvertTime(utcNowDateTime, easternTimeZoneInfo);
        //Gets todays date
        DateTime easternNowDate = easternNowDateTime.Date;
        //Gets 5:35pm today or tomorrow depending on whether we are past 5:35pm or not. 
        //  Even though there are actually 18 hours from midnight to 5:35pm on Nov 2 2014 and 16 hours from midnight to 5:35pm on March 9 2014, 
        //  this will still end up at 5:35pm on those days because DateTime DOESNOT take into account the movement of the clocks (foreward or backward) when calling 
        //  .AddHours(), etc
        DateTime easternExpiryDateTime = easternNowDate.AddHours(17).AddMinutes(35).AddDays(easternNowDateTime.Hour >= 18 || (easternNowDateTime.Hour == 17 && easternNowDateTime.Minute >= 35) ? 1 : 0);
        //Convert the Easter Time date time to UTC. When subtracting this time from another UTC DateTime you will get the correct TimeSpan for use with a timer
        //  (even on 23 such as March 10th and 25 hour days such as November 3rd 2013)
        DateTime utcExpiryDateTime = easternExpiryDateTime.ToUniversalTime();
        //Set the timer to trigger at the desired point in the future.
        Timer timer = new Timer(
           ...,
           null,
           utcExpiryDateTime - utcNowDateTime ,
           ...);
