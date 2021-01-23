    public string Date(string yourDate)
    {
        PersianCalendar pdate = new PersianCalendar();
        DateTime nT = new DateTime();
        nT = DateTime.Parse(yourDate);
        string s = String.Format("{0}/{1}/{2}", pdate.GetYear(nT), pdate.GetMonth(nT), pdate.GetDayOfMonth(nT));
        return s;
    }
