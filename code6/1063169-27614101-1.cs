    public string FormatHebrewDate(DateTime dtGregorian)
    {
                    System.Globalization.HebrewCalendar hCal = new System.Globalization.HebrewCalendar();
                    string sDate = hCal.GetDayOfMonth(dtGregorian).ToString() + " ";
                    if (hCal.IsLeapYear(hCal.GetYear(dtGregorian)))
                    {
                        sDate += Globals.HebrewMonthNamesLeapYear[hCal.GetMonth(dtGregorian) - 1];
                    }
                    else
                    {
                        sDate += Globals.HebrewMonthNames[hCal.GetMonth(dtGregorian) - 1];
                    }
                    sDate += " " + hCal.GetYear(dtGregorian).ToString();
                    return sDate;
    }
