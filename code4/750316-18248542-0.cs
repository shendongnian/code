    public IEnumerable<Appointment> FindAllAppointmentsWithReminders()
    {
        DateTime reminderDate = DateTime.Today.Date;
    **DateTime NewDate =reminderDate.Date;**
        IEnumerable<Appointment> apps = RepositorySet    
            .OfType<Appointment>()
            .Include("Client")
            .Where(c => EntityFunctions.TruncateTime(c.Client.Reminder.Date) == **NewDate** 
                            && reminderDate.Date > EntityFunctions.TruncateTime(c.StartTime.Date));
    
        return apps;
    }          
