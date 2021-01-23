    protected String getDate(string date)
    {
        DateTime dDate;
        string sdate = null;
        if (!string.IsNullOrEmpty(date.ToString()))
        {
            dDate = DateTime.Parse(date.ToString());
            sdate = dDate.ToString("dd/MM/yyyy");
            sdate = dDate.ToLongDateString();
        }
        return sdate;
    }
