    public static partial class MyExtensions
    {
        public static  IEnumerable<string> SplitByLength_LB(this string input, int maxLen)
        {
            return Regex.Split(input, @"(.{1," + maxLen + @"})(?:\s|$)")
                        .Where(x => x.Length > 0)
                        .Select(x => x.Trim());
        }
        public static IEnumerable<string> SplitByLength_tinstaafl(this string input, int maxLen)
        {
            List<string> output = new List<string>();
            while (input.Length > 0)
            {
                output.Add(new string(input.Take(maxLen).ToArray()));
                input = new string(input.Skip(maxLen).ToArray());
            }
            return output;
        }
    }
