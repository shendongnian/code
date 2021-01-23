    public string Date()
    {
        string result = null, year = null, month = null, day;
        PersianCalendar PC = new PersianCalendar();
        year = PC.GetYear(DateTime.Now).ToString();
        month = PC.GetMonth(DateTime.Now).ToString();
        day = PC.GetDayOfMonth(DateTime.Now).ToString();
        result = year + "/" + month + "/" + day;
        return result;
    }
