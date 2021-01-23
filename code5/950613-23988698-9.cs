    foreach (var pattern in CultureInfo.CurrentCulture.
                                        DateTimeFormat.
                                        GetAllDateTimePatterns())
    {
         Console.WriteLine(pattern);
    }
