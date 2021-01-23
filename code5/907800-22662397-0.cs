    private void TimeZonesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TimeZoneInfo info = (TimeZoneInfo)timeZoneListBox.SelectedItem;
        dstCheckBox.Visible = info.SupportsDaylightSavingTime;
        dstCheckBox.Checked = GetPreviousConfiguration(info);
    }
    private bool GetPreviousConfiguration(TimeZoneInfo timezone)
    {
         //Code to lookup previous config.
    }
