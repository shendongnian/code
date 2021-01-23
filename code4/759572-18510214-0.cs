    String tmpDate = "Friday, 27th September 2013";
    tmpDate = tmpDate.Replace("nd", "")
                .Replace("th", "")
                .Replace("rd", "")
                .Replace("st", "");            
    string[] formats = { "dddd, dd MMMM yyyy" };
    DateTime dt;
    if (DateTime.TryParseExact(tmpDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out dt))
    {
         //parsing is successful
    }
