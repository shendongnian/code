    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date > DateTime.Now)    // use any selection criteria
        {
            // you can do all kinds of stuff here
            e.Cell.Enabled = false;
            e.Cell.ForeColor = Color.DarkGray;
        }
    }
