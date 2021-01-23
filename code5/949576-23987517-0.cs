            CalendarView cv = new CalendarView(DateTime.Now,DateTime.Now.AddDays(200),100);
            FindItemsResults<Appointment>findresults = service.FindAppointments(WellKnownFolderName.Calendar, cv);
            foreach (Appointment aptval in findresults.Items)
            {
                Console.WriteLine(aptval.LegacyFreeBusyStatus);        
            }
