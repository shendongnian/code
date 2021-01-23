    string date = "02/27/2014 23:00:28";
    string pattern = "MM/dd/yyyy HH:mm:ss";
    DateTime parsedDate;
    bool test= DateTime.TryParseExact(date, pattern,
                                      CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out parsedDate);
    Console.WriteLine(test); // True
