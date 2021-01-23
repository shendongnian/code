    // Define cultures to be used to parse dates.
          CultureInfo[] cultures = {CultureInfo.CreateSpecificCulture("en-US"), 
                                    CultureInfo.CreateSpecificCulture("fr-FR"), 
                                    CultureInfo.CreateSpecificCulture("de-DE")};
          // Define string representations of a date to be parsed. 
          string[] dateStrings = {"01/10/2009 7:34 PM", 
                                  "10.01.2009 19:34", 
                                  "10-1-2009 19:34" };
          // Parse dates using each culture. 
          foreach (CultureInfo culture in cultures)
          {
             DateTime dateValue;
             Console.WriteLine("Attempted conversions using {0} culture.", 
                               culture.Name);
             foreach (string dateString in dateStrings)
             {
                try {
                   dateValue = DateTime.Parse(dateString, culture);
                   Console.WriteLine("   Converted '{0}' to {1}.",
                                     dateString, dateValue.ToString("f", culture));
                }
                catch (FormatException) {
                   Console.WriteLine("   Unable to convert '{0}' for culture {1}.", 
                                     dateString, culture.Name);
                }
             }
             Console.WriteLine();
