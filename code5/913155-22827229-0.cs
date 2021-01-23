    var uk = CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat;
    uk.MonthDayPattern = "dd/MM";
    var us = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
    us.MonthDayPattern = "MM/dd";
    Console.WriteLine(DateTime.Now.ToString("m", uk)); // 03/04
    Console.WriteLine(DateTime.Now.ToString("m", us)); // 04/03
