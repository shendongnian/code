    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> requestedDays = new List<string>();
        requestedDays = Session["daysre"] as List<string>;
        StringBuilder theRequestedDaysStringBuilder = new StringBuilder();
     
        foreach(string day in requestedDays)
        {
            theRequestedDaysStringBuilder.Append(day);
        }
        daysLabel.Text = String.Format("You picked" + theRequestedDaysStringBuilder.ToString());
    }
