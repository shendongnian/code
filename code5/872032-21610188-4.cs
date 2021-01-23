    private static void calendarSelectedDatesChanged(object sender, SelectionChangedEventArgs e) 
    {
        // Skipped a few lines of code
        if (popup != null) 
        {
            contentHost.Content = calendar.SelectedDate;
            popup.IsOpen = false;
        }
    }
