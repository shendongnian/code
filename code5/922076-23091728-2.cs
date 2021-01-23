    public static string Parse(string s)
    {
        return '"' + InnerParse(s).Replace(";", "\",\"") + '"';
    }
    private static string InnerParse(string s)
    {
        int pos;
        while ((pos = s.IndexOf('(')) != -1)
        {
            int count = 1;
            int nextPos = pos;
            while (count != 0)
            {
                nextPos = s.IndexOfAny(new[] { ')', '(' }, nextPos + 1);
                if (nextPos == -1 || nextPos >= s.Length)
                    throw new ApplicationException();   // Unpaired parentheses
                count = s[nextPos] == '(' ? count + 1 : count - 1;
            }
            s = (pos != 0 ? s.Substring(0, pos - 1) : String.Empty)
                + InnerParse(s.Substring(pos + 1, nextPos - pos - 1))   // Recursion
                + s.Substring(nextPos + 1);
        }
        string[] operands = s.Split(new[] { "AND", "OR" }, StringSplitOptions.None);
        if (operands.Length != 2)
            throw new ApplicationException();   // Count of operands != 2
        string op1 = operands[0].Trim();
        string op2 = operands[1].Trim();
        // If operator is OR
        if (s.Contains("OR"))
            return op1 + ';' + op2;
        // If operator is AND
        string[] op1s = op1.Split(';');
        string[] op2s = op2.Split(';');
        string[] ret = new string[op1s.Length * op2s.Length];
        int i = 0;
        foreach (string s1 in op1s)
            foreach (string s2 in op2s)
                ret[i++] = s1 + ',' + s2;
        return String.Join(";", ret);
    }
