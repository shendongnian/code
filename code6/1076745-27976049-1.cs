    protected void beginning_date_TextChanged(object sender, EventArgs e)
    {
        DateTime date;
        DateTime.TryParse(beginning_date.Text, out date);
        beginning_day.Text = date.DayOfWeek.ToString();
    }
