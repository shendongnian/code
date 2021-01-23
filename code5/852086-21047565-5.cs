    var supportedFormats = new[] { 
        new{ Pattern = culture.DateTimeFormat.ShortDatePattern, Type = "DateOnly" },
        new{ Pattern = culture.DateTimeFormat.ShortDatePattern, Type = "TimeOnly" },
        new{ Pattern = culture.DateTimeFormat.LongDatePattern, Type  = "DateOnly" },
        new{ Pattern = culture.DateTimeFormat.LongDatePattern, Type  = "DateOnly" },
        new{ Pattern = "hhtt", Type = "TimeOnly"},
        new{ Pattern = culture.DateTimeFormat.ShortDatePattern + " " + culture.DateTimeFormat.LongTimePattern, Type="DateAndTime" }
    };
    bool dtTimeOnly, dtDateOnly, dtDateAndTime;
    foreach(var fi in supportedFormats)
    {
        DateTime dt;
        if(DateTime.TryParseExact("01/02/2014 00:00:00", fi.Pattern, culture, DateTimeStyles.NoCurrentDateDefault, out dt))
        {
            switch (fi.Type)
            {
                case "TimeOnly":
                    dtTimeOnly = true;
                    dtDateOnly = false;
                    dtDateAndTime = false;
                    break;
                case "DateOnly":
                    dtTimeOnly = false;
                    dtDateOnly = true;
                    dtDateAndTime = false;
                    break;
                case "DateAndTime":
                    dtTimeOnly = false;
                    dtDateOnly = false;
                    dtDateAndTime = true;
                    break;
                default:
                    throw new NotSupportedException("Unsupported type: " + fi.Type);
            }
            break;
        }
    }
