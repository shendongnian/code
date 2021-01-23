        //First, your entry does not include AM or PM.
        //Therefore it is considered a time format 24H
        string inputDate="2013-03-05T08:28:18+0000";
        //We indicate culture, although in this step is not necessary.
        DateTime d = DateTime.Parse(inputDate,CultureInfo.InvariantCulture);
        //Your date, contains the modifier +0000, indicating a time zone
        //We must become universal time, or local time is displayed
        //If you only want 1 digit for the hours, minutes, seconds, when their value < 10, we use a single symbol format
        // 01:02:03 ->1:2:3 using h:m:s -> 01:02:03 using hh:mm:ss
        //We use invariant culture, or we want to display the data
        string ouputDate = d.ToUniversalTime().ToString("MMM d, yyyy h:m:s tt", CultureInfo.InvariantCulture);
        // ouputDate ="Mar 5, 2013 8:28:18 AM"; 
        // Because your date dont include any time zone specifier, if want to convert to DateTime, must specify some
        // or DateTimeKind.Unspecified is used
        //Try this
        Console.WriteLine(ouputDate);
        DateTime d2 = DateTime.SpecifyKind(DateTime.Parse(ouputDate,CultureInfo.InvariantCulture),DateTimeKind.Utc);
        Console.WriteLine(d2);
        DateTime d3 = d2.ToLocalTime();
        Console.WriteLine(d3);
        DateTime d4 = d2.ToUniversalTime();
        Console.WriteLine(d4);
    //Here d2 is DateTimeKind.Unspecified, the strange result happen in the conversion to string
        d2 = DateTime.Parse(ouputDate,CultureInfo.InvariantCulture);
        Console.WriteLine(d2);
        d3 = d2.ToLocalTime();
        Console.WriteLine(d3);
        d4 = d2.ToUniversalTime();
        Console.WriteLine(d4);
