    public static DateTime GregorianToUmAlQura(this DateTime gregorianDate)
    {
        Calendar umAlQura = new UmAlQuraCalendar();
        return new DateTime(umAlQura.GetYear(gregorianDate), umAlQura.GetMonth(gregorianDate), umAlQura.GetDayOfMonth(gregorianDate), umAlQura);
    }
