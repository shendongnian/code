    CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
    
    DateTimeFormatInfo dtfi = ci.DateTimeFormat;
    Assembly coreAssembly = Assembly.ReflectionOnlyLoad("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
    Type dateTimeParseType = coreAssembly.GetType("System.DateTimeParse");
    MethodInfo getMonthDayOrderMethodInfo = dateTimeParseType.GetMethod("GetMonthDayOrder", BindingFlags.Static | BindingFlags.NonPublic);
    object[] parameters = new object[] { dtfi.MonthDayPattern, dtfi, null };
    getMonthDayOrderMethodInfo.Invoke(null, parameters);
    int order = (int)parameters[2];
    switch (order)
    {
        case -1:
            Console.WriteLine("Cannot extract information");
            break;
        case 6:
            Console.WriteLine("MM/dd");
            break;
        case 7:
            Console.WriteLine("dd/MM");
            break;
    }
