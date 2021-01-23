    public static string Replace(string input, int value, int index)
    {
           string pattern = @"(\d+)|(\d+)|(\d+),(\d+)";
    
           return Regex.Replace(input, pattern, match =>
           {
                if (match.Index == index * 2) //multiply by 2 for | and , character.
                {
                    return value.ToString();
                }
    
                return match.Value;
          });
     }
