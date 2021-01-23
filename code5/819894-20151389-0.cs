    string year = "1997";
    string month = "5";
    string day = "28";
    string dateText = string.Format("{0}/{1}/{3}", year, month, day);
    DateTime date;
    
    if (!DateTime.TryParseExact(dateText, "yyyy/MM/dd", null, DateTimeStyles.None, out date))
    {
        Console.WriteLine("Date is invalid");
    }
