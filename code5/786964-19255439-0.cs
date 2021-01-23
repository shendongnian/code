    List<string> strDates = new List<string>
    {
        "201101..",
        "199008..",
        "20110202",
    };
    string[] possibleFormats = new[] { "yyyyMM", "yyyydd", "yyyyMd" }; 
                                                         //single M and d to parse
                                                        //both single and double digit
                                                        //Month or Day
                                                      
                                                                       
    DateTime dt; 
    foreach(string str in strDates)
    {
        if (DateTime.TryParseExact(str.Trim('.'), 
                                possibleFormats, 
                                CultureInfo.InvariantCulture, 
                                DateTimeStyles.None, 
                                out dt))
        {
            Console.WriteLine(dt);
        }
        else
        {
            Console.WriteLine("Invalid date");
        }
    }
