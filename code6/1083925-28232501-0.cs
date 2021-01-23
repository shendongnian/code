    var date = "20140231";
    DateTime scope;
    bool dateValid = DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.None, out scope);
    while (!dateValid)
    {
        string yearMonth = date.Substring(0, 4);
        int day = Convert.ToInt32(date.Substring(6, 2));
        if (day > 1)
        {
            day--;
        }
        else
        {
            break;
        }
        date = yearMonth + day.ToString().PadLeft(2, '0');
        dateValid = DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.None, out scope);
    }
