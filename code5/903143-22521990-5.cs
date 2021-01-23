     public static DateTimeOffset ParseIso8061Time(string s)
     {
        var styles = DateTimeStyles.AllowWhiteSpaces |
            (s.EndsWith("Z") 
               ? DateTimeStyles.AssumeUniversal 
               : DateTimeStyles.AssumeLocal);
        return DateTimeOffset.ParseExact(s, Iso8061DateTimeForms,
            CultureInfo.InvariantCulture, styles);
     }
