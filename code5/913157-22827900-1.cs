    var de = CultureInfo.CreateSpecificCulture("de-DE").DateTimeFormat;
    var uk = CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat;
    var us = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
    
    var now = DateTime.Now;
    var yearNow = now.Year.ToString(CultureInfo.InvariantCulture);
    const string yearPattern = "(^{0}{1}|{1}{0}$)"; // {0} = year, {1} = date separator
    
    var deDate = now.ToString("d", de);
    var deYearlessDate =
        Regex.Replace(
            deDate,
            String.Format(yearPattern, yearNow, de.DateSeparator),
            "");
    // or a double String.Replace instead of a Regex.Replace
    //var deYearlessDate =
    //    deDate.Replace(de.DateSeparator + yearNow, "").Replace(yearNow + de.DateSeparator, "");
    
    var ukDate = now.ToString("d", uk);
    var ukYearlessDate =
        Regex.Replace(
            ukDate,
            String.Format(yearPattern, yearNow, uk.DateSeparator),
            "");
    // or a double String.Replace instead of a Regex.Replace
    //var ukYearlessDate =
    //    ukDate.Replace(uk.DateSeparator + yearNow, "").Replace(yearNow + uk.DateSeparator, "");
    
    var usDate = now.ToString("d", us);
    var usYearlessDate =
        Regex.Replace(
            usDate,
            String.Format(yearPattern, yearNow, us.DateSeparator),
            "");
    // or a double String.Replace instead of a Regex.Replace
    //var usYearlessDate =
    //    usDate.Replace(us.DateSeparator + nowYear, "").Replace(nowYear + us.DateSeparator, "");
    
    Console.WriteLine(deYearlessDate); // 02.04
    Console.WriteLine(ukYearlessDate); // 02/04
    Console.WriteLine(usYearlessDate); // 4/2
