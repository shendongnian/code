    DateTime start = DateTime.Parse(StartTime_DDL.SelectedItem.Text);
    DateTime end = DateTime.Parse(EndTime_DDL.SelectedItem.Text);
    double duration = double.Parse(SlotDuration_DDL.SelectedItem.Text);
	string header = "<div class='priority low'><span><strong>{0}</strong></span></div>";
    string morning = "";
    string afternon = "";
	bool doneMornHeader = false, doneAfternoonHeader = false;
    while (true)
    {
        DateTime dtNext = start.AddMinutes(duration);
        if (start > end || dtNext > end)
            break;
        if (start < DateTime.Parse("12:00 PM"))
        {
			if(!doneMornHeader)
			{
				Label head = new Label();
				head.Text = string.Format(header, "Morning");
				this.Timediv.Controls.Add(head);
                                doneMornHeader= true;
			}
            morning = start.ToShortTimeString() + "-" + dtNext.ToShortTimeString() + "<br>";
            Label lbl = new Label();
            lbl.Text = morning;
            CheckBox cb = new CheckBox();
            this.Timediv.Controls.Add(lbl);
            this.Timediv.Controls.Add(cb);
        }
        else
        {
			if(!doneAfternoonHeader)
			{
				Label head = new Label();
				head.Text = string.Format(header, "Afternoon");
				this.Timediv.Controls.Add(head);
                                doneAfternoonHeader = true;
			}
            afternon = start.ToShortTimeString() + "-" + dtNext.ToShortTimeString() + "<br>";
            Label lbl1 = new Label();
            lbl1.Text = afternon;
            CheckBox cb1 = new CheckBox();
            this.Timediv.Controls.Add(lbl1);
            this.Timediv.Controls.Add(cb1);
        }
        start = dtNext;
    }
