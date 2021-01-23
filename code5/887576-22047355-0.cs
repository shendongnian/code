    static readonly Dictionary<DateTime, string> m_Holidays = new Dictionary<DateTime,string>
    {
        { new DateTime(1,1,1), "New Years Day" },
        { new DateTime(1,7,4), "Independence Day" },
        { new DateTime(1,7,4), "Independence Day" },
        /*FILL OUT ALL OF THE HOLIDAYS YOU WANT TO OBSERVE*/
    };
    public bool isHoliday(DateTime date)
    {
        return m_Holidays.HasKey(new DateTime(1, date.Month, date.Day));
    }
    public bool getHolidayName(DateTime date)
    {
        return m_Holidays[new DateTime(1, date.Month, date.Day)];
    }
