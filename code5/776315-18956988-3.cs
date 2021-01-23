    var days = Enum.GetValues(typeof(DayOfWeek));
    foreach (DayOfWeek dayOfWeek in days)
    {
        var dayAppointments = foundAppointments.SelectMany(x => x.Where(y => y.StartTime.Date.DayOfWeek == dayOfWeek)).ToList();
        Appointments.Add(dayAppointments);
    }
