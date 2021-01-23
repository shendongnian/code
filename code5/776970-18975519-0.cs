       private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
           AganedaInformation info = GetAgendaDetails(e.Start.Date);
        }
Add a private method to query the database based on the passed selected date
    Private AganedaInformation GetAgendaDetails(DateTime selectedDate)
    {
      //Add logic to query the database with the selected date and return the information
    }
