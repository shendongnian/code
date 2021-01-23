    using System.Text.RegularExpressions;
    public static class _Extensions
    {
        public static string ToStringFriendly(this Enum e)
        {
            string s = e.ToString();
            // enforce a charset: letters, numbers, and underscores
            s = Regex.Replace(s, "[^A-Za-z0-9_]", ""); 
            // separate numbers from letters
            s = Regex.Replace(s, "([a-zA-Z])([0-9])", "$1 $2"); 
            // separate letters from numbers
            s = Regex.Replace(s, "([0-9])([a-zA-Z])", "$1 $2"); 
            // space lowercases before uppercase (word boundary)
            s = Regex.Replace(s, "([a-z])([A-Z])", "$1 $2"); 
            // see that the nice pretty capitalized words are spaced left
            s = Regex.Replace(s, "(?!^)([^ _])([A-Z][a-z]+)", "$1 $2"); 
            // replace double underscores with colon-space delimiter
            s = Regex.Replace(s, "__", ": "); 
            // finally replace single underscores with hyphens
            s = Regex.Replace(s, "_", "-"); 
            return s;
        }
    }
