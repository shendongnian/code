    var input = "This string is really long. There are a lot of words in it.\r\nHere's another line in the string that's also very long.";
    var lines = input.SplitByLength(20).ToList();
---
 
    public static partial class MyExtensions
    {
        public static  IEnumerable<string> SplitByLength(this string input, int maxLen)
        {
            return Regex.Split(input, @"(.{1," + maxLen + @"})(?:\s|$)")
                        .Where(x => x.Length > 0);
        }
    }
