    public static class NameDoesNotMatter {
       public static string smartSingleQuote(this string s) {
          string result = s.Replace("'","''");
          return result;
       } 
    }
