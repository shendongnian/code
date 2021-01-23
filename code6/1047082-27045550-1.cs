    private string GetDays(Schedule schedule)
    {
        var stringBuilder = new StringBuilder();
        if (schedule.Mon == 1)
        {
            stringBuilder.Append("M");
        }
        if (schedule.Tue == 1)
        {
            stringBuilder.Append("T");
        }
        if (schedule.Wed == 1)
        {
            stringBuilder.Append("W");
        }
        if (schedule.Thu == 1)
        {
            stringBuilder.Append("TH");
        }
        if (schedule.Fri == 1)
        {
            stringBuilder.Append("F");
        }
        if (schedule.Sat == 1)
        {
            stringBuilder.Append("SAT");
        }
        if (schedule.Sun == 1)
        {
            stringBuilder.Append("SUN");
        }
        if (schedule.Mon1 == 1)
        {
            stringBuilder.Append("M1");
        }
        if (schedule.Tue1 == 1)
        {
            stringBuilder.Append("T1");
        }
        if (schedule.Wed1 == 1)
        {
            stringBuilder.Append("W1");
        }
        if (schedule.Thu1 == 1)
        {
            stringBuilder.Append("TH1");
        }
        if (schedule.Fri1 == 1)
        {
            stringBuilder.Append("F1");
        }
        if (schedule.Sat1 == 1)
        {
            stringBuilder.Append("SAT1");
        }
        if (schedule.Sun1 == 1)
        {
            stringBuilder.Append("SUN1");
        }
        if (stringBuilder.Length == 0)
        {
            stringBuilder.Append("NO SCHEDULE");
        }
        return stringBuilder.ToString();
    }
