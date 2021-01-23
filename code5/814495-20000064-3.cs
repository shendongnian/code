        DateTime start = DateTime.Parse( StartTime_DDL.SelectedItem.Text);
        DateTime end = DateTime.Parse(EndTime_DDL.SelectedItem.Text);
        double duration = double.Parse(SlotDuration_DDL.SelectedItem.Text);
        string morning = "";
        string afternon = "";
        while (true)
        {
            DateTime dtNext = start.AddMinutes(duration);
            if (start > end || dtNext > end)
                break;
            if (start < DateTime.Parse("12:00 PM"))
            {
                morning += start.ToShortTimeString() + "-" + dtNext.ToShortTimeString() + "<br>";
            }
            else
            {
                afternon += start.ToShortTimeString() + "-" + dtNext.ToShortTimeString() + "<br>";
            }
            start = dtNext;
        }
        if (morning.Length > 0)
            morning = "<B>Morning</B><BR>" + morning;
        if (afternon.Length > 0)
            afternon = "<B>Afternon</B><BR>" + afternon;
        Label lbl = new Label();
        lbl.Text = morning + afternon;
        Form.Controls.Add(lbl);
