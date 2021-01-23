    public static string GetDateLabel(DateTime testDate)
    {
        if(HolidayTester.IsDayOff(testDate))
            return "NT";
        else
            return "TR";
    }
