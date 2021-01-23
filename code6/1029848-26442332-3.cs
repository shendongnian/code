    public static class StringExtensions
    {
         public static int CountMatches(this string source, string searchText)
         {
            if(string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(searchText))
               return 0;
             int counter = 0;
             int startIndex = -1;
             while((startIndex = (source.IndexOf(searchText, startIndex + 1))) != -1)
                 counter++;
             return counter;
         }
    }
