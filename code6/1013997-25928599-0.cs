    List<string> dueDates = new List<string>();
    dueDates.Add("All");
    dueDates.Add(new DateTime(2001,03,01).ToString());
    dueDates.Add(new DateTime(2002, 04, 01).ToString());
    dueDates.Add(new DateTime(2003, 05, 01).ToString());
    cbDates.DataSource = dueDates;
