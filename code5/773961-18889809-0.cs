    // string timeAsString = "1:20";
    TimeSpan time;
    if (TimeSpan.TryParse(timeAsString, CultureInfo.InvariantCulture, out time))
    {
        double minutes = time.TotalMinutes;
        //... continue 
    }
    else
    {
        // Ask user to input time in correct format
    }
