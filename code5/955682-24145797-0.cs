    List<DateTime> validDates = new List<DateTime>();
    DateTime startTime = DateTime.Now.Date;
    for (int index = 0; index < 48; index++)
    {
        if (startTime > DateTime.Now)
        {
            validDates.Add(startTime);
        }
        startTime = startTime.AddMinutes(30);
    }
