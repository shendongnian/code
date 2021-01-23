    DateTime d;
    DateTime.TryParseExact(date, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.NoCurrentDateDefault, out d);
    
    if (d== DTM)
