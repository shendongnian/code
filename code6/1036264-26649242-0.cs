    string date = "2014-10-30 10:00:04";  
    string duration = "05:02:10";  
    DateTime dt1 = DateTime.Parse(date, System.Globalization.CultureInfo.InvariantCulture);
    TimeSpan ts = TimeSpan.Parse(duration);
    DateTime dtFinal = dt1.Add(ts);
    string final = dtFinal.ToString("yyyy-MM-dd HH:mm:ss");
