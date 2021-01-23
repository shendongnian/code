    string strDate = "4/1/2014 1:16:32 AM";
    DateTime datDate;
    if (DateTime.TryParseExact(strDate, new string[] { "M/d/yyyy h:m:s tt" },
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out datDate))
    {
        Console.WriteLine(datDate);
    }
