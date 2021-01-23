    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        // Disable the date being rendered if it is not in the DB-returned dates.
        if (!_databaseDates.Contains(e.Day.Date))
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = Color.Gray; // or e.Cell.Font.Strikeout = true;
        }
    }
