    IEnumerable<DayOfWeek> daysOfWeek = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
    
    var appointmentsOnDaysOfWeek = daysOfWeek
        .GroupJoin(
            foundAppointments,
            dayOfWeek => dayOfWeek,
            appointment => appointment.StartDate.DayOfWeek,
            (day, appointments) => new
            {
                Day = day,
                Appointments = appointments.ToList()
            })
        .OrderBy(appointmentsOnDay => appointmentsOnDay.Day)
        .Select(appointmentsOnDay => appointmentsOnDay.Appointments);
    Appointments.AddRange(appointmentsOnDaysOfWeek);
