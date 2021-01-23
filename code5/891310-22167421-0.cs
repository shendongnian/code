    private DayOfWeek[] AllowedDays = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Thursday };
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = AllowedDays.Contains(e.Day.Date.DayOfWeek);
    }
