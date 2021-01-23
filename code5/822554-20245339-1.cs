     //A few different strings to test
     string dts1 = "25-11-2013 6:25:33";
     string dts2 = "11/25/2013 6:25:33";
     string dts3 = "25-11-2013 06:25:33";
     string dts4 = "11/25/2013 06:25:33";
     string dts5 = "25-11-2013 6:25:33 PM";
     string dts6 = "11/25/2013 6:25:33 PM";
     string dts7 = "25-11-2013 06:25:33 PM";
     string dts8 = "11/25/2013 06:25:33 PM";
     string dts9 = "25-11-2013 6:5:33 PM";
     string dts10 = "11/25/2013 6:5:33 PM";
     //The supported datetime formats as an array
     string[] dateFormats = { 
                                   "dd-MM-yyyy hh:mm:ss tt",
                                   "dd-MM-yyyy h:mm:ss tt",
                                   "dd-MM-yyyy h:m:ss tt",
                                   "dd-MM-yyyy HH:mm:ss",
                                   "dd-MM-yyyy H:mm:ss",
                                   "dd-MM-yyyy H:m:ss",
                                   "MM/dd/yyyy hh:mm:ss tt",
                                   "MM/dd/yyyy h:mm:ss tt",
                                   "MM/dd/yyyy h:m:ss tt",
                                   "MM/dd/yyyy HH:mm:ss",
                                   "MM/dd/yyyy H:mm:ss",
                                   "MM/dd/yyyy H:m:ss"
                         };
            
     //Parse all the sample strings
     DateTime dt1 = DateTime.ParseExact(dts1, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
     DateTime dt2 = DateTime.ParseExact(dts2, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
     DateTime dt3 = DateTime.ParseExact(dts3, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
     DateTime dt4 = DateTime.ParseExact(dts4, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
     DateTime dt5 = DateTime.ParseExact(dts5, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
     DateTime dt6 = DateTime.ParseExact(dts6, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
     DateTime dt7 = DateTime.ParseExact(dts7, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
     DateTime dt8 = DateTime.ParseExact(dts8, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
     DateTime dt9 = DateTime.ParseExact(dts9, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
     DateTime dt10 = DateTime.ParseExact(dts10, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            
