    partial void SetToday_Execute()
    {
        var cal = this.FindControl("Calendar1");
        cal.ControlAvailable += (object sender, ControlAvailableEventArgs e) =>
            {
                var c = (System.Windows.Controls.Calendar)e.Control;
                c.SelectedDate = DateTime.Now;
                c.DisplayDate = DateTime.Now;
            };
    }
