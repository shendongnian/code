    string date = "20141021";
    string year = date.Substring(0, 4);
    string month = date.Substring(4, 2);
    string day = date.Substring(6, 2);
    string formatted = year + "-" + month + "-" + day;
    DateTime myDate = DateTime.ParseExact(formatted,"yyyy-MM-dd",
                                   System.Globalization.CultureInfo.InvariantCulture);
