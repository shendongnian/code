    DateTime result;
    if (DateTime.TryParseExact(
        recievedDateTxt.Text,           // The string you want to parse
        "dd/MM/yyyy",                   // The format of the string you want to parse.
        CultureInfo.InvariantCulture,   // The culture that was used
                                        // to create the date/time notation
        DateTimeStyles.None,            // Extra flags that control what assumptions
                                        // the parser can make, and where whitespace
                                        // may occur that is ignored.
        out result))                    // Where the parsed result is stored.
    {
           // your other codes 
           cmd.Parameters.Add("@dilivery_date", SqlDbType.Date).Value = result; 
    }
