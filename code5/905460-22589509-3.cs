    public static string ReplaceIncrement(string input, int incrementValue, int index)
    {
                string pattern = @"(\d+)|(\d+)|(\d+),(\d+)";
    
                return Regex.Replace(input, pattern, match =>
                {
                    if (match.Index == index * 2)
                    {
                        return (int.Parse(match.Value) + incrementValue).ToString();
                    }
    
                    return match.Value;
                });
     }
