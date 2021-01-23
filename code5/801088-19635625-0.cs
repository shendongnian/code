        private static DateTime getTodayNow(string timeZoneId="")
        {
            DateTime retVal = DateTime.Now;
          
            DateTime.TryParse(DateTime.Now.ToString("s"), out retVal);
            if (!string.IsNullOrEmpty(timeZoneId))
            {
                try
                {
                    DateTime now = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToUniversalTime();
                    TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);//"Russian Standard Time");
                    retVal = TimeZoneInfo.ConvertTimeFromUtc(now, easternZone);
                }
                catch (Exception ex)
                {
                }
            }
            return retVal;
        }
