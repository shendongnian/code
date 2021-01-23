    private void btnAddHour_Click( object sender, RoutedEventArgs e )
    {
        DateTime curDate;
        bool isParsed = DateTime.TryParse(txtHH.Text, out curDate);
        if (!isParsed)
          curDate = DateTime.Now;
        txtHH.Text =curDate.AddHours( 1 ).ToString("HH");
    }
