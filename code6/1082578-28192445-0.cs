     AppointmentStore appointmentStore = await AppointmentManager.RequestStoreAsync(AppointmentStoreAccessType.AllCalendarsReadOnly);
            FindAppointmentsOptions options = new FindAppointmentsOptions();
            options.MaxCount = 100;
            options.FetchProperties.Add(AppointmentProperties.Subject);
            options.FetchProperties.Add(AppointmentProperties.Location);
            options.FetchProperties.Add(AppointmentProperties.Invitees);
            options.FetchProperties.Add(AppointmentProperties.Details);
            options.FetchProperties.Add(AppointmentProperties.StartTime);
            options.FetchProperties.Add(AppointmentProperties.ReplyTime);
            IReadOnlyList<Windows.ApplicationModel.Appointments.Appointment> appointments = await appointmentStore.FindAppointmentsAsync(DateTime.Now, TimeSpan.FromHours(24), options);
            foreach (var appointment in appointments)
            {
                var persistentId = appointment.RoamingId;
                var details = appointment.Details;//the details is empty, why
                var invitees = appointment.Invitees;//the invitees is also empty, why?
            }
