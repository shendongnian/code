        List<DateTime> theDates = new List<DateTime>();
        DateTime fileDate, closestDate;
        theDates.Add(new DateTime(2000, 1, 1, 10, 29, 0));
        theDates.Add(new DateTime(2000, 1, 1, 3, 29, 0));
        theDates.Add(new DateTime(2000, 1, 1, 3, 29, 0));
        // This is the date that should be found
        theDates.Add(new DateTime(2000, 1, 1, 4, 22, 0));
        CultureInfo cf = new CultureInfo("en-us");
        string timeToParse = phonecurrentime.ToString("dd hh:mm");
        if(DateTime.TryParseExact(timeToParse, "dd hh:mm", cf, DateTimeStyles.None, out fileDate))
        {
            long min = long.MaxValue;
            foreach (DateTime date in theDates)
            {
                if (Math.Abs(date.Ticks - fileDate.Ticks) < min)
                {
                    min = Math.Abs(date.Ticks - fileDate.Ticks);
                    closestDate = date;
                }
            }
         }
