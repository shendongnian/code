    Appointment a = new Appointment(Service);
    // If using Exchange 2007 SP1
    a.StartTimeZone = Service.TimeZone;
    
    // If using Exchange 2010 or Higher
    a.StartTimeZone = Service.TimeZone;
    a.EndTimeZone = Service.TimeZone;
    
