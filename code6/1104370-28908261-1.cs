      public static class StringExtension
     {
       public static string RemoveLastWord(this string value, string separator = "")
       {
         if (string.IsNullOrWhiteSpace(value))
            return string.Empty;
         if (string.IsNullOrWhiteSpace(separator))
            separator = "/";
         var words = value.Split(Char.Parse(separator));
         if (words.Length == 1)
            return value;
         value = string.Join(separator, words.Take(words.Length - 1));
         return value;
      }
    }
