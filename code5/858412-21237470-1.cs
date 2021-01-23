    private void tbltoday_Click(object sender, EventArgs e)
    {
        DayOfWeek v = DateTime.Today.DayOfWeek;
        if(v != DayOfWeek.Sunday && v != DayOfWeek.Saturday)
            outputtbl.Text = Variables.DayText[v];
    }
