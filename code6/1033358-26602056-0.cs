    public static Collection<DateTime> GetDuplicateSlots(
            TimeZoneInfo timeZone, DateTime start, int intervalLength, int numOfIntervals)
        {
            Collection<DateTime> duplicates = new Collection<DateTime>();
            bool dstAtStart = timeZone.IsDaylightSavingTime(start);
            for (int interval = 0; interval < numOfIntervals; interval++)
            {
                DateTime current = start.Date.AddMinutes(interval * intervalLength);
                if (dstAtStart)
                {
                    if (!timeZone.IsDaylightSavingTime(current))
                    {
                        duplicates.Add(current);
                        duplicates.Add(current.AddMinutes(intervalLength));
                        return duplicates;
                    }
                }
                else
                {
                    if (timeZone.IsDaylightSavingTime(current))
                    {
                        duplicates.Add(current);
                        duplicates.Add(current.AddMinutes(intervalLength));
                        return duplicates;
                    }
                }
            }
            return duplicates;  // no duplicates
        }
