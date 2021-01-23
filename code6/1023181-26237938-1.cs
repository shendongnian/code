     public static string Group(this string s, int groupSize = 3, char groupSeparator = ' ')
     {
         var formattedIdentifierBuilder = new StringBuilder();
         for (int i = 0; i < s.Length; i++)
         {
             if ((s.Length - i) % groupSize == 0)
             {
                 formattedIdentifierBuilder.Append(groupSeparator);
             }
             formattedIdentifierBuilder.Append(s[i]);
         }
         return formattedIdentifierBuilder.ToString();
     }
