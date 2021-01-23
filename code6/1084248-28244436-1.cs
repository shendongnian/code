    DateTime someDate = new DateTime(); //or an array of dates, then run a loop
    private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
    {
        if (monthCalendar1.SelectionStart == someDate)
        {
            monthCalendar1.BackColor = SystemColors.someColor;
        }
        else
        {
            monthCalendar1.BackColor = SystemColors.Control;
        }
    }
