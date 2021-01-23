      void Appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
      {
         try
         {
            AppointmentResultsData.DataContext = e.Results;
            MessageBox.Show(e.Results.ElementAt<Appointment>(0).Subject.ToString());
         }
         catch (System.Exception) { }
      }
