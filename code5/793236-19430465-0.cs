        public static DateTime FromUnixTime(long unixTime)
        {
            unixTime = unixTime / 1000000;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
