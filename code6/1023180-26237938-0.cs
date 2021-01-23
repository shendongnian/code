     public static string FormatNumericIdentifier(this string s)
     {
         var formattedIdentifierBuilder = new StringBuilder();
         for (int i = 0; i < s.Length; i++)
         {
             if ((s.Length - i) % 3 == 0)
             {
                 formattedIdentifierBuilder.Append(' ');
             }
             formattedIdentifierBuilder.Append(s[i]);
         }
         return formattedIdentifierBuilder.ToString();
     }
