    protected void beginning_date_TextChanged(object sender, EventArgs e)
    {
        var input = (TextBox)sender;    // could use "beginning_date" - it doesn't matter
        DateTime date;
        DateTime.TryParse(input.Text, out date);
        beginning_day.Text = date.DayOfWeek.ToString();
    }
