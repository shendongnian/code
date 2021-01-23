    var sortedList = 
    list
    .OrderBy(
        s =>
            DateTime.ParseExact(
                System.Web.HttpUtility.ParseQueryString(s).Get("time"),
                "yyyyMMddHHmm",
                System.Globalization.CultureInfo.InvariantCulture));
