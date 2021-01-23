    DateTime dateResult;
    System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
    string dateFormat = "yyyy-dd-MM HH:mm";
    string dateToCheck = "2013-20-10 00:00";
    dateResult = DateTime.ParseExact(dateToCheck, dateFormat, provider);
