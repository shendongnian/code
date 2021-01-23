    List<string> result = new List<string>();
    DateTime startDate = new DateTime(2012, 1, 8);
    DateTime endDate = new DateTime(2013, 1, 3);
    DateTime temp = startDate;
    endDate = new DateTime (endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year,endDate.Month));
    while (temp <= endDate)
    {
        Console.WriteLine((string.Format("{0}/{1}", temp.Month, temp.Year));
        temp = temp.AddMonth(1);
    }
