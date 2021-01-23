    public static DateTime? TryGetDateExact(this string item, String[] allowedFormats = null, params IFormatProvider[] formatProvider)
    {
        if (formatProvider.Length == 0)
            formatProvider = new[] { CultureInfo.CurrentCulture };
        if (allowedFormats == null || allowedFormats.Length == 0)
        {
            allowedFormats = formatProvider
            .Select(fp => { 
                DateTimeFormatInfo dti = DateTimeFormatInfo.GetInstance(fp); 
                return String.Format("{0} {1}", dti.ShortDatePattern, dti.ShortTimePattern);
            })
            .ToArray();
        }
        bool success = false;
        DateTime d = DateTime.MinValue;
        foreach (var provider in formatProvider)
        {
            success = DateTime.TryParseExact(item, allowedFormats, provider, DateTimeStyles.None, out d);
            if (success) break;
        }
        return success ? (DateTime?)d : (DateTime?)null;
    }
