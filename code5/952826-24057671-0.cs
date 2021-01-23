    private String CheckTime(String value)
    {
        // change user input into valid format
        if(System.Text.RegularExpressions.Regex.IsMatch(value, "(^\\d$)|(^\\d{3}$)"))
            value = "0"+value;
        String[] formats = { "HH mm", "HHmm", "HH:mm", "H mm", "Hmm", "H:mm", "H" };
        DateTime expexteddate;
        if (DateTime.TryParseExact(value, formats, System.Globalization.CultureInfo.InvariantCulture,     System.Globalization.DateTimeStyles.None, out expexteddate))
           return expexteddate.ToString("HH:mm");
        else
           throw new Exception(String.Format("Not valid time inserted, enter time like:     {0}HHmm", Environment.NewLine));
    }
    
