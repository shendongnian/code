    Appointment a = new Appointment(Service);
    // If using Exchange 2007 SP1
    a.StartTimeZone = TimeZoneInfo.Local;
    
    // If using Exchange 2010 or Higher
    a.StartTimeZone = TimeZoneInfo.Local;
    a.EndTimeZone = TimeZoneInfo.Local;
