    public DateTimeType GetDateTimeType(string input, CultureInfo culture, out DateTime parsedDate)
    { 
       if(culture == null) culture = CultureInfo.CurrentCulture;
       var supportedFormats = new[] { 
            new{ Pattern = culture.DateTimeFormat.ShortDatePattern, Type = DateTimeType.Date },
            new{ Pattern = culture.DateTimeFormat.ShortTimePattern, Type = DateTimeType.Time },
            new{ Pattern = culture.DateTimeFormat.LongDatePattern, Type  = DateTimeType.Date },
            new{ Pattern = culture.DateTimeFormat.LongTimePattern, Type  = DateTimeType.Time },
            new{ Pattern = "hhtt", Type = DateTimeType.Time},
            new{ 
                Pattern = culture.DateTimeFormat.ShortDatePattern + " " + culture.DateTimeFormat.LongTimePattern, 
                Type = DateTimeType.DateTime
            }
        };
        foreach(var fi in supportedFormats)
        {
            DateTime dt;
            if (DateTime.TryParseExact(input, fi.Pattern, culture, DateTimeStyles.NoCurrentDateDefault, out dt))
            {
                parsedDate = dt;
                return fi.Type;
            }
        }
        parsedDate = default(DateTime);
        return DateTimeType.Unknown;
    }
