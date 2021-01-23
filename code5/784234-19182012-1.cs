    //My input string
    var input  = Regex.Replace(input  , "[\\\"](.+)[\\\"]", ReplaceMethod);
    //Method used to replace 
    public static string ReplaceMethod(Match m)
        {
            string newValue = m.Value;
            return newValue.Replace("\"", "").Replace(",", ";");
        }
