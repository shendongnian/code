    string s = "4/1/2014 1:16:32 AM";
    DateTime date;
    if (DateTime.TryParseExact(s, "M/d/yyyy h:mm:ss tt",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out date))
    {
         Console.WriteLine(date);
    }
    else
    {
         Console.WriteLine("Your string is not valid.");
    }
