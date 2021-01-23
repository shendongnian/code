        string code = "2014P07W4";
        int yr = int.Parse(code.Substring(0, 4));
        int mnth = int.Parse(code.Substring(5, 2));
        int week = int.Parse(code.Substring(8));
        DateTime dt = new DateTime(yr, mnth, 1);
        if (dt.DayOfWeek == DayOfWeek.Monday)
        {
            DateTime newdate = dt.AddDays((8 - (int)dt.DayOfWeek) % 7 + ((week - 1) * 7));
        }
        else
        {
            DateTime newdate = dt.AddDays((8 - (int)dt.DayOfWeek) % 7 + ((week - 2) * 7));
        }
