    public static DateTimeFormatInfo GetInstance(IFormatProvider provider) {
        // Fast case for a regular CultureInfo
        DateTimeFormatInfo info;
        CultureInfo cultureProvider = provider as CultureInfo;
        if (cultureProvider != null && !cultureProvider.m_isInherited)
        {
            return cultureProvider.DateTimeFormat;
        }
        // Fast case for a DTFI;
        info = provider as DateTimeFormatInfo;
        if (info != null) {
            return info;
        }
        // Wasn't cultureInfo or DTFI, do it the slower way
        if (provider != null) {
            info = provider.GetFormat(typeof(DateTimeFormatInfo)) as DateTimeFormatInfo;
            if (info != null) {
                return info;
            }
        }
        // Couldn't get anything, just use currentInfo as fallback
        return CurrentInfo;
     }
