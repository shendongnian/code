        public static String[] SplitCsv(String value) {
          if (Object.ReferenceEquals(null, value))
            return null;
    
          const Char quotation = '\'';
          const Char separator = ',';
    
          List<String> result = new List<String>();
    
          Boolean inQuotation = false;
          Boolean isStarted = false;
    
          StringBuilder Sb = new StringBuilder();
    
          foreach (Char Ch in value) {
            if (inQuotation) {
              Sb.Append(Ch);
              inQuotation = Ch != quotation;
    
              continue;
            }
    
            if (Ch == separator) {
              result.Add(Sb.ToString());
              Sb.Length = 0;
              isStarted = true;
            }
            else {
              Sb.Append(Ch);
              isStarted = false;
              inQuotation = Ch == quotation;
            }
          }
    
          if (isStarted || (Sb.Length > 0))
            result.Add(Sb.ToString());
    
          return result.ToArray();
        }
    
      ....
    
      var test1 = SplitCsv("1,2,3");   // <- ["1", "2", "3"]
      var test2 = SplitCsv("1,2,");    // <- ["1", "2", ""]
      var test3 = SplitCsv("1,'2',3"); // <- ["1", "'2'", "3"]
      var test4 = SplitCsv("1,'2,3'"); // <- ["1", "'2,3'"]
      var test5 = SplitCsv("1,''");    // <- ["1", "''"]
