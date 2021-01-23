    class Program
    {
        static IEnumerable<string> Parts(string input, out int i)
        {
            var list = new List<string>();
            int level = 1, start = 1;
            i = 1;
            for (; i < input.Length && level > 0; i++)
            {
                if (input[i] == '[')
                    level++;
                else if (input[i] == ']')
                    level--;
                if (input[i] == '/' && level == 1 || input[i] == ']' && level == 0)
                {
                    if (start == i)
                        list.Add(string.Empty);
                    else
                        list.Add(input.Substring(start, i - start));
                    start = i + 1;
                }
            }
            return list;
        }
        static IEnumerable<string> Combinations(string input, string current = "")
        {
            if (input == string.Empty)
            {
                if (current.Contains('['))
                    return Combinations(current, string.Empty);
                return new List<string> { current };
            }
            else if (input[0] == '[')
            {
                int end;
                var parts = Parts(input, out end);
                return parts.SelectMany(x => Combinations(input.Substring(end, input.Length - end), current + x)).ToList();
            }
            else
                return Combinations(input.Substring(1, input.Length - 1), current + input[0]);
        }
        static void Main(string[] args)
        {
            string s = "[I am/I'm] [[un/]certain/[/un]sure].";
            var list = Combinations(s);
        }
    }
