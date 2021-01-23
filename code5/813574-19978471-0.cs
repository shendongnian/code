    using (SqlCommand cmd2 = new SqlCommand("insert into EventDays(EventDay,EventStatus)values(@EventDay,@EventStatus)", con))
    {
        var paramDay = cmd2.Parameters.Add("@EventDay", SqlDbType.DateTime);
        var paramStatus = cmd2.Parameters.Add("@EventStatus", SqlDbType.Int);
        for (int i = 0; i < n; i++)
        {
            Label NewLabel = new Label();
            NewLabel.ID = "Label" + i;
    
            var eventDate = Calendar1.SelectedDate.Date.AddDays(i);
            NewLabel.Text = eventDate.ToLongDateString();
            NewLabel.CssClass = "h1size";
            CheckBox newcheck = new CheckBox();
            newcheck.ID = "CheckBox" + i;
            this.Labeldiv.Controls.Add(NewLabel);
            this.Checkboxdiv.Controls.Add(newcheck);
            this.Labeldiv.Controls.Add(new LiteralControl("<br/>"));
            paramDay.Value = eventDate;
            paramStatus.Value = newCheck.Checked ? 1 : 0;
            cmd2.ExecuteNonQuery();
        }
    }
