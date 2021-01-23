        protected void EventDuration_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            Labeldiv.Controls.Clear();
            int n = Int32.Parse(EventDuration_DDL.SelectedItem.ToString());
            for (int i = 0; i < n; i++)
            {
                SqlCommand cmd = new SqlCommand("insert into EventDays(EventDay,EventStatus)values(@EventDay,@EventStatus)", con);
                Label NewLabel = new Label();
                NewLabel.ID = "Label" + i;
                var eventDate = DateTime.Now.AddDays(i); //Calendar1.SelectedDate.Date.AddDays(i);
                NewLabel.Text = eventDate.ToLongDateString();
                CheckBox newcheck = new CheckBox();
                newcheck.AutoPostBack = true;
                newcheck.ID = "CheckBox" + i;
                newcheck.CheckedChanged += new EventHandler(newcheck_CheckedChanged);
                this.Labeldiv.Controls.Add(new LiteralControl("<span class='h1size'>"));
                this.Labeldiv.Controls.Add(NewLabel);
                this.Labeldiv.Controls.Add(new LiteralControl("</span>"));
                this.Labeldiv.Controls.Add(new LiteralControl("<div class='make-switch pull-right' data-on='info'>"));
                this.Labeldiv.Controls.Add(newcheck);
                this.Labeldiv.Controls.Add(new LiteralControl("</div>"));
                this.Labeldiv.Controls.Add(new LiteralControl("<br/>"));
                cmd.Parameters.AddWithValue("@EventDay", NewLabel.Text);
                cmd.Parameters.AddWithValue("@EventStatus", newcheck.Checked ? 1 : 0);
                cmd.ExecuteNonQuery();
            }
        protected void newcheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentCheckbox = sender as CheckBox;
            string extractInteger = Regex.Match(currentCheckbox.ID, @"\d+").Value;
            Label currentlabel = (Label)Labeldiv.FindControl("Label" + extractInteger);
        }
