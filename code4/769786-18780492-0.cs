    int i = 0;
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (i < 11)
            {
                i++;
                saveAppointmentTask = new SaveAppointmentTask();
                saveAppointmentTask.StartTime = new DateTime(1, 1, 1); ;
                saveAppointmentTask.EndTime = new DateTime(1, 1, 1).AddMinutes(3);
                saveAppointmentTask.Subject = "Meet Ali"; // appointment subject
                saveAppointmentTask.Location = "In Office"; // appointment location
                saveAppointmentTask.Details = "Meet Ali to discuss product launch";//appointment details
                saveAppointmentTask.IsAllDayEvent = false;
                saveAppointmentTask.Reminder = Microsoft.Phone.Tasks.Reminder.FifteenMinutes;
                saveAppointmentTask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.OutOfOffice;
                saveAppointmentTask.Show();
            }
            else { 
            }
        }
