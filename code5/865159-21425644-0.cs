    DateTime? dtStartDate = strStartDate.MyParse();
    static DateTime? MyParse(this string value) {
        if(value == null) return null;
        return DateTime.ParseExact(value, "dd.MM.yyyy",
             System.Globalization.CultureInfo.InvariantCulture
    );
