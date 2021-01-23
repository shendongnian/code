        string date = "2014,03,04,11,00,00";
        DateTime datDate;
        if(DateTime.TryParseExact(date, new string[] { "yyyy,MM,dd,hh,mm,ss" },
                              System.Globalization.CultureInfo.InvariantCulture,
                              System.Globalization.DateTimeStyles.None, out datDate))
        {
          Console.WriteLine(datDate);
        }
