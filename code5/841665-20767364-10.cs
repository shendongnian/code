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
            List<string> output = new List<string>{""};
            string[] temp = input.Split("\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < temp.Count(); i++)
            {
                if((output.Last() + " " + temp[i]).Length > 50)
                {
                    output.Add(temp[i]);
                }
                else
                    output[output.Count() - 1] += " " + temp[i];
            }
            return output;
        }
            return output;
        }
