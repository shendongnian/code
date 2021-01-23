    // Helper method
    IEnumerable<string> DateTimeFormatPatterns(DateTimeFormatInfo format)
    {
    	var accessors = new Func<DateTimeFormatInfo, string>[]
    	{
    		f => f.FullDateTimePattern,
    		f => f.LongDatePattern,
    		f => f.LongTimePattern,
    		f => f.MonthDayPattern,
    		f => f.ShortDatePattern,
    		f => f.SortableDateTimePattern,
    		f => f.UniversalSortableDateTimePattern,
    		f => f.YearMonthPattern,
    	};
    	
    	return accessors.Select(accessor => accessor(format));
    }
    // The real function
    string DetectDateTimeFormat(string date, CultureInfo culture)
    {
        DateTime dummy;
        foreach (var pattern in DateTimeFormatPatterns(culture.DateTimeFormat))
        {
            if (DateTime.TryParseExact(date, pattern, culture,
                                       DateTimeStyles.None, out dummy))
            {
                return pattern;
            }
        }
    	
        return null;
    }
