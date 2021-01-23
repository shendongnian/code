    private void SetDays()
    {
        listBoxBuildDays.DataSource = Enum.GetValues(typeof(DayOfWeek));
        listBoxBuildDays.SelectedIndex = 0;
    }
