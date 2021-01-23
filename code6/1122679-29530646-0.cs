            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(60);
            const int NUM_APPTS = 1000;
            // Initialize the calendar folder object with only the folder ID. 
            CalendarFolder calendar = CalendarFolder.Bind(service, WellKnownFolderName.Calendar, new PropertySet());
            // Set the start and end time and number of appointments to retrieve.
            CalendarView cView = new CalendarView(startDate, endDate, NUM_APPTS);
            // Limit the properties returned to the appointment's subject, start time, and end time.
            cView.PropertySet = new PropertySet(AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End,AppointmentSchema.Categories);
            // Retrieve a collection of appointments by using the calendar view.
            FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);
            Console.WriteLine("\nThe first " + NUM_APPTS + " appointments on your calendar from " + startDate.Date.ToShortDateString() +
                              " to " + endDate.Date.ToShortDateString() + " are: \n");
            foreach (Appointment a in appointments)
            {
                if (a.Categories.Contains("Green"))
                {
                    Console.Write("Subject: " + a.Subject.ToString() + " ");
                    Console.Write("Start: " + a.Start.ToString() + " ");
                    Console.Write("End: " + a.End.ToString());
                }                
                Console.WriteLine();
            }
