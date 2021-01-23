    void ClubCalendar_VisibleMonthChanged(Object sender, MonthChangedEventArgs e)
        {
            StartDate = e.NewDate;
            CalendarPanel.Update();
        }
