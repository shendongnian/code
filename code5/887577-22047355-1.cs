    class VariableHoliday
    {
        public string Name {get; set;}
        
        public bool IsOnDate(DateTime date)
        {
             //logic to detect the variable dates goes here!
        }
    }
    static readonly Dictionary<DateTime, string> m_Holidays = new Dictionary<DateTime,string>
    {
        { new DateTime(1,1,1), "New Years Day" },
        { new DateTime(1,7,4), "Independence Day" },
        { new DateTime(1,7,4), "Independence Day" },
        /*FILL OUT ALL OF THE HOLIDAYS YOU WANT TO OBSERVE*/
    };
    static List<VariableHolidays> m_VariableHolidays = new List<VariableHolidays>();
    public bool isHoliday(DateTime date)
    {
        bool isHoliday = m_Holidays.HasKey(new DateTime(1, date.Month, date.Day));
        
        if(!isHoliday)
            m_VariableHolidays.Any(p => p.IsOnDate(date));
    }
    public string getHolidayName(DateTime date)
    {
        if(m_Holidays.HasKey())
            return m_Holidays[new DateTime(1, date.Month, date.Day)];
        else
        {
            var holiday = m_VariableHolidays.FirstOrDefault(p => p.IsOnDate(date));
            if(holiday != null) return holiday.Name
        }
        throw new InvalidOperationException("Date is not a holiday");
    }
