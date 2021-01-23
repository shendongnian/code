    String input = "Hello[Left][Left]This is a test string[Left][Left][Left][Left]";
    MatchCollection c = Regex.Matches(input, "(?:\\[Left\\])+");
    StringBuilder output = new StringBuilder();
    int start = 0;
    foreach (Match m in c)
    {
        output.Append(input.Substring(start, m.Index - start));
        output.AppendFormat("[Left x {0}]", m.Length / 6);
        start = m.Index + m.Length;
    }
    output.Append(input.Substring(start));
    Console.Write(output.ToString());
