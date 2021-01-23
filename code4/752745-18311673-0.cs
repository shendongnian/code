    string input = "Aug 16 21:06:52 +0000 2013";
    DateTime output;
    if (DateTime.TryParseExact(input, "MMM dd HH:mm:ss zzzz yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out output))
    { 
        // date was parsable, here is it:
        Console.WriteLine(output.ToLongDateString());
    }
