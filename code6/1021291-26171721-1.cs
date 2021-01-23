    public static DateTimeFormatInfo CurrentInfo {
        get {
            Contract.Ensures(Contract.Result<DateTimeFormatInfo>() != null);
            System.Globalization.CultureInfo culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (!culture.m_isInherited) {
                DateTimeFormatInfo info = culture.dateTimeInfo;
                if (info != null) {
                    return info;
                }
            }
            return (DateTimeFormatInfo)culture.GetFormat(typeof(DateTimeFormatInfo));
        }
    }
