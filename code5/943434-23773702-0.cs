            //Get local Date
            DateTime lD = DateTime.Now; // or DateTime.Today;
            //Get utc date
            DateTime utcD = DateTime.UtcNow;
            //To Convert utc to local
            DateTime fromUtcToLocal = utcD.ToLocalTime(); //Using your OS default regional settings/time zone
            //To specific region/time zone of your choice
            var tzi = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            var choosenLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcD, tzi);
