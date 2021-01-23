    public static List<DateTime> GetHolidays(string holidaysFile)
    {
	    string[] sAllDates = File.ReadAllLines(holidaysFile);
        return (from sDate in sAllDates select Convert.ToDateTime(sDate)).ToList();
    }
