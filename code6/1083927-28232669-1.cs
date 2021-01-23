    string date = "20140231";
    DateTime result;
    int year = Convert.ToInt32(date.Substring(0, 4));
    int month = Convert.ToInt32(date.Substring(4, 2));
    int day = Convert.ToInt32(date.Substring(6, 2));
    if (day > DateTime.DaysInMonth(year, month))
    {
        result = new DateTime(year, month, DateTime.DaysInMonth(year, month));
    }
    else
    {
        result = new DateTime(year, month, day);
    }
