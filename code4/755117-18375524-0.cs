    public DateTime StartOfMonth(DateTime dateTime)
    {
          return new DateTime(dateTime.Year, dateTime.Month, 1);
    }
    public DateTime EndOfMonth(DateTime dateTime)
    {
          DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
          return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
    }
    private void button1_Click_2(object sender, EventArgs e)
    {
          DateTime startMonth = StartOfMonth(DateTime.Now);
          DateTime endMonth = EndOfMonth(DateTime.Now);
          monthCalendar1.SelectionRange = new SelectionRange(startMonth, endMonth);
    }
