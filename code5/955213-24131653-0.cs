           public static string ConvertDtFormat(string dateTimeString)
           {
               dateTimeString = dateTimeString.Trim();
               while (dateTimeString.Contains("  "))
               {
                   dateTimeString = dateTimeString.Replace("  ", " ");
               }
 
               if (dateTimeString == null || dateTimeString.Length == 0)
               {
                   return string.Empty;
               }
               else
               {
                   DateTime convertedDateTime = new DateTime();
                   string userDateFormat = HMS.DEFAULT_DATE_FORMAT;
 
                   try
                   {
                       if (userDateFormat.Trim().Contains("dd/MM/yyyy"))
                           convertedDateTime = DateTime.ParseExact(dateTimeString, format_dmy, CultureInfo.InvariantCulture,
                                                                   DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite);
                       else if (userDateFormat.Trim().Contains("MM/dd/yyyy"))
                           convertedDateTime = DateTime.ParseExact(dateTimeString, format_mdy, CultureInfo.InvariantCulture,
                                                                   DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite);
 
                       return convertedDateTime.ToString("MMM dd, yyyy hh:mm tt");
                   }
                   catch
                   {
                       return "Invalid DateTime";
                   }
               }
           }
