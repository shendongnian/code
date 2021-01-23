    public static partial class MyExtensions
    {
        public static IEnumerable<string> SplitByLength_LB(this string input, int maxLen)
        {
            return Regex.Split(input, @"(.{1," + maxLen + @"})(?:\s|$)")
                        .Where(x => x.Length > 0)
                        .Select(x => x.Trim());
        }
        public static IEnumerable<string> SplitByLength_tinstaafl(this string input, int maxLen)
        {
            List<string> output = new List<string>();
            input = input.Trim("\n ".ToCharArray());
            while(input.Length > 0)
            {
                output.Add(new string(input.TakeWhile((x, y) => input.IndexOf(' ', y) <= maxLen || x != '\n').ToArray()));
                input = input.Substring(output.Last().Length);
                output[output.Count - 1] = output[output.Count - 1].TrimStart("\n ".ToCharArray());
            }
            return output;
        }
