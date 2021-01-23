    string format = "yyyy-MM-dd-HH.mm.ss.ffffff";
                DateTime result;
                const String Date = "2014-07-23 06:00"; ;
    
                try
                {
                    
                    DateTime datDateStarted;
                    DateTime.TryParseExact(Date, new string[] { "yyyy-MM-dd HH:ss" }, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out datDateStarted);
                    Console.WriteLine(datDateStarted);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not in the correct format.", format);
                }
