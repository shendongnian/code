    public enum ParserState
    {
        ExpectSign = 0,
        ExpectValue = 1
    }
    public static void Parse()
    {
        string filterMe = "foo=1;bar=foo+5;foobar=foo+5-bar;";
        var rows = filterMe.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> locals = new Dictionary<string, int>();
        foreach (string split in rows)
        {
            var row = split.Split('=');
            if (row.Length != 2)
            {
                throw new Exception();
            }
            string name = row[0].Trim();
            string exp = row[1].Trim();
            if (!Regex.IsMatch(name, "^[A-Za-z_]+$"))
            {
                throw new Exception();
            }
            Regex rx = new Regex(@"\G(?:(?<local>[A-Za-z_]+)|(?<constant>[0-9]+)|(?<sign>[+-]))");
            var subExps = rx.Matches(exp).OfType<Match>().ToArray();
            if (subExps.Length == 0 || subExps[subExps.Length - 1].Index + subExps[subExps.Length - 1].Length != exp.Length)
            {
                throw new Exception();
            }
            int result = 0;
            ParserState state = ParserState.ExpectValue;
            string currentSign = "+";
            foreach (var subExp in subExps)
            {
                {
                    Group sign = subExp.Groups["sign"];
                    if (sign.Success)
                    {
                        if (state != ParserState.ExpectSign)
                        {
                            throw new Exception();
                        }
                        currentSign = sign.ToString();
                        state = ParserState.ExpectValue;
                        continue;
                    }
                }
                {
                    Group local = subExp.Groups["local"];
                    if (local.Success)
                    {
                        if (state != ParserState.ExpectValue)
                        {
                            throw new Exception();
                        }
                        int value;
                        if (!locals.TryGetValue(local.ToString(), out value))
                        {
                            throw new Exception();
                        }
                        result = Operation(result, value, currentSign);
                        state = ParserState.ExpectSign;
                    }
                }
                {
                    Group constant = subExp.Groups["constant"];
                    if (constant.Success)
                    {
                        if (state != ParserState.ExpectValue)
                        {
                            throw new Exception();
                        }
                        int value = int.Parse(constant.ToString());
                        result = Operation(result, value, currentSign);
                        state = ParserState.ExpectSign;
                    }
                }
                if (state != ParserState.ExpectSign)
                {
                    throw new Exception();
                }
            }
            locals[name] = result;
        }
    }
    private static int Operation(int result, int value, string currentSign)
    {
        if (currentSign == "+")
        {
            return result + value;
        }
            
        if (currentSign == "-")
        {
            return result - value;
        }
            
        throw new ArgumentException();
    }
