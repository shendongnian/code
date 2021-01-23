    public static void ParseComplex(string input)
    {
        char[] operators = new[] { '+', '-', '*', '/' };
        Regex regex = new Regex("[0-9]+[.]?[0-9]+i?|[+-/*]?");
        foreach (Match match in regex.Matches(input))
        {
            if (string.IsNullOrEmpty(match.Value))
                continue;
            if (operators.Contains(match.Value[0]))
            {
                Console.WriteLine("operator {0}", match.Value[0]);
                continue;
            }
            if (match.Value.EndsWith("i"))
            {
                Console.WriteLine("imaginary part {0}", match.Value);
                continue;
            }
            else
            {
                Console.WriteLine("real part {0}", match.Value);
            }
        }
    }
    
