        private static IEnumerable<DateTime> ParseFreeBusy(string freeBusyString, DateTime startingDate)
        {
            var timeSlots = new HashSet<DateTime>();
            var utc = startingDate.ToUniversalTime();
            var timeZone = TimeZone.CurrentTimeZone; //can change to particular time zone, currently set to local timezone of the system
            for (int i = 0; i < freeBusyString.Length; i++)
            {
                double slot = i * 30;
                DateTime timeSlot = utc.AddMinutes(slot);
                bool isFree = freeBusyString.Substring(i, 1) == "0";
                if (isFree)
                {
                    var localTimeSlot = timeZone.ToLocalTime(timeSlot);
                    timeSlots.Add(localTimeSlot);
                }
            }
            return timeSlots;
        }
