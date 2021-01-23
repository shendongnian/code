    foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
    {
        var dayAppointments = foundAppointments.SelectMany(x=>x.Where(y => y.StartTime.Date.DayOfWeek == dayOfWeek)).ToList();
        Appointments.Add(dayAppointments);
    }
