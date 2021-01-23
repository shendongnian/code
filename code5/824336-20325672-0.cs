    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
                StartDate_TB.Text = DateTime.Today.ToShortDateString();
            EventDuration();
           
    }
    private void EventDuration()
    {
            DateTime dt = DateTime.Parse(StartDate_TB.Text);
            int n = Int32.Parse(EventDuration_DDL.SelectedItem.ToString());
            for (int i = 0; i < n; i++)
            {
                Label NewLabel = new Label();
                NewLabel.ID = "Label" + i;
                var eventDate = dt.AddDays(i);
                NewLabel.Text = eventDate.ToLongDateString();
                CheckBox newcheck = new CheckBox();
                newcheck.ID = "CheckBox" + i;
                this.Labeldiv.Controls.Add(new LiteralControl("<div class='row-fluid'>"));
                this.Labeldiv.Controls.Add(new LiteralControl("<span class='h1size'>"));
                this.Labeldiv.Controls.Add(NewLabel);
                this.Labeldiv.Controls.Add(new LiteralControl("</span>"));
                this.Labeldiv.Controls.Add(new LiteralControl("<div class='make-switch pull-right' data-on='info'>"));
                this.Labeldiv.Controls.Add(newcheck);
                this.Labeldiv.Controls.Add(new LiteralControl("</div>"));
                this.Labeldiv.Controls.Add(new LiteralControl("</div>"));
                this.Labeldiv.Controls.Add(new LiteralControl("<br/>"));
            }
    }
