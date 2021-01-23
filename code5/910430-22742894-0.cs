    if (DateTime.TryParseExact(strStartDate, new string[] { "dd/MM/yyyy" } ,
                                   System.Globalization.CultureInfo.InvariantCulture,
                                   System.Globalization.DateTimeStyles.None, out datStartDate)
        &&
        DateTime.TryParseExact(strEndDate, new string[] { "dd/MM/yyyy" } ,
                                   System.Globalization.CultureInfo.InvariantCulture,
                                   System.Globalization.DateTimeStyles.None, out datEndDate)
       )
       {
           updateEventGridviewRecord(id, strEventType, strEventName, datStartDate);
       }
