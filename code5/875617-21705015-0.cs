    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.DayOfWeek == DayOfWeek.Wednesday)
        {
            e.Cell.Controls.Clear();
        }
    }
