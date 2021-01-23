    public static HtmlString TimeSpanString(this HtmlHelper helper, TimeSpan val)
    {
        double days = val.Days;
        double hours = val.Hours + (days * 24);
        double minutes = val.Minutes;
        double seconds = val.Seconds;
        var formattedString = String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        return new HtmlString("<span>" + formattedString + "</span>");
    }
