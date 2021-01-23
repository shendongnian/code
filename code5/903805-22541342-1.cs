        public static int ObtainYear(String value) {
          if (String.IsNullOrEmpty(value))
            throw new ArgumentNullException("value");
          // two ou four digits possibly followed by any spaces and/or dots
          Match match = Regex.Match(value, @"(\d{2}|\d{4})(\.| )*$");
    
          if (!match.Success) 
            throw new ArgumentException("value");
    
          int year = int.Parse(match.Groups[0].Value.Trim(' ', '.'), CultureInfo.InvariantCulture);
    
          // If you get two digits year you should add either 1900 or 2000
          if (year < 30)
            year += 2000;
          else if (year < 1000)
            year += 1900;
    
          return year;
        }
        ...
        int result1 = ObtainYear("Jenuary 01, 2003."); // <- 2003 
        int result2 = ObtainYear("01:02:79 ."); // <- 1979
