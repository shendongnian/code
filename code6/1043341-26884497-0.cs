    var date = "30/10/14 08:60";
    DateTime dateResult;
    bool canParse = DateTime.TryParseExact(date, "dd/MM/yy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateResult);
    if (!canParse)
    {
        string datePart = date.Split().First();
        DateTime dtOnly;
        if (DateTime.TryParseExact(datePart, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtOnly))
        {
            string timePart = date.Split().Last();
            string hourPart = timePart.Split(':')[0];
            string minutePart = timePart.Split(':').Last();
            int hour, minute;
            if (int.TryParse(hourPart, out hour) && int.TryParse(minutePart, out minute))
            {
                TimeSpan timeOfDay = TimeSpan.FromHours(hour) + TimeSpan.FromMinutes(minute);
                dateResult = dtOnly + timeOfDay;  // 10/30/2014 09:00:00
            }
        }
    }
