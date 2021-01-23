    public void setBirthdate(int year, int month, int day)
    {
        if (year >= 1 && year <= 9999 && month >= 1 && month <= 12)
        {
            int[] days = DateTime.IsLeapYear(year)
                ? new[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365}
                : new[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366};
            if (day >= 1 && day <= days[month] - days[month - 1])
                Birthdate = new DateTime(year, month, day);
        }
        else
            Birthdate = DateTime.Today;
    }
