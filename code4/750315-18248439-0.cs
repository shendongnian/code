    public IEnumerable<Appointment> FindAllAppointmentsWithReminders()
    {
        DateTime reminderDate = DateTime.Today.Date;
        IEnumerable<Appointment> apps = RepositorySet    
            .OfType<Appointment>()
            .Include("Client")
            .Where(c => EntityFunctions.TruncateTime(c.Client.Reminder) == reminderDate 
                            && reminderDate > EntityFunctions.TruncateTime(c.StartTime));
    
        return apps;
    }
