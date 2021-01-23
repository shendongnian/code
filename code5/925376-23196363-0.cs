    public static CultureInfo EnglishIndia = new CultureInfo("en-IN");
    //To use the rupee symbol please change "en-IN" to "hi-IN"
    public static String ToLocalFormat(this decimal value)
    {
        return string.Format(Constants.EnglishIndia, "{0:#,0.00}", value);
    }
