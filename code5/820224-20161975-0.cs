    DateTime start = DateTime.Parse(StartTime_DDL.SelectedItem.Text);
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
            morning = start.ToShortTimeString() + "-" + dtNext.ToShortTimeString() + "<br>";
            Label lbl = new Label();
            lbl.Text = morning;
            CheckBox cb = new CheckBox();
            this.Timediv.Controls.Add(lbl);
            this.Timediv.Controls.Add(cb);
        }
        else
        {
            afternon = start.ToShortTimeString() + "-" + dtNext.ToShortTimeString() + "<br>";
            Label lbl1 = new Label();
            lbl1.Text = afternon;
            CheckBox cb1 = new CheckBox();
            this.Timediv.Controls.Add(lbl1);
            this.Timediv.Controls.Add(cb1);
        }
        start = dtNext;
    }
    if (morning.Length > 0)
        morning = "<div class='priority low'><span><strong>Morning</strong></span></div>" + morning;
    if (afternon.Length > 0)
        afternon = "<div class='priority medium'><span><strong>Afternoon</strong></span></div>" + afternon;
