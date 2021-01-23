    public static string Replace(
        string input
    ,   ref int pos
    ,   IDictionary<string,string> vars
    ,   bool stopOnClose = false
    ) {
        var res = new StringBuilder();
        while (pos != input.Length) {
            switch (input[pos]) {
                case '\\':
                    pos++;
                    if (pos != input.Length) {
                        res.Append(input[pos++]);
                    }
                    break;
                case ')':
                    if (stopOnClose) {
                        return res.ToString();
                    }
                    res.Append(')');
                    pos++;
                    break;
                case '$':
                    pos++;
                    if (pos != input.Length && input[pos] == '(') {
                        pos++;
                        var name = Replace(input, ref pos, vars, true);
                        string replacement;
                        if (vars.TryGetValue(name, out replacement)) {
                            res.Append(replacement);
                        } else {
                            res.Append("<UNKNOWN:");
                            res.Append(name);
                            res.Append(">");
                        }
                        pos++;
                    } else {
                        res.Append('$');
                    }
                    break;
                default:
                    res.Append(input[pos++]);
                    break;
            }
        }
        return res.ToString();
    }
    public static void Main() {
        const string input = "Here is a test string contain $(variableA) and $(variableB$(variableC))";
        var vars = new Dictionary<string, string> {
            {"variableA", "A"}, {"variableB", "B"}, {"variableC", "C"}, {"variableBC", "Y"}
        };
        int pos = 0;
        Console.WriteLine(Replace(input, ref pos, vars));
    }
