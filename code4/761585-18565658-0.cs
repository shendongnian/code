    bool dateParsed = false;
    DateTime date;
    CultureInfo provider = CultureInfo.InvariantCulture;
    string when = "Sat 27 Apr 2013 7:30pm";
    dateParsed = DateTime.TryParseExact(when, "ddd d MMM yyyy h:mmtt", provider, DateTimeStyles.AssumeLocal, out date);
    Console.WriteLine(date);
    date = new DateTime(2013, 4, 27, 19, 30, 00, DateTimeKind.Local);
    Console.WriteLine(date.ToString("ddd d MMM yyyy h:mmtt", provider));
