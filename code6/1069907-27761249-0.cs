    public IEnumerable<Appointment> Get()
    {
        // Initialize values for the start and end times, and the number of appointments to retrieve.
        DateTime startDate = DateTime.Now;
        DateTime endDate = startDate.AddDays(30);
        const int NUM_APPTS = 50;
        
        // Snipped for brevity
    
        // Retrieve a collection of appointments by using the calendar view.
        FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);
    
        return  appointments.AsEnumerable();
    }
