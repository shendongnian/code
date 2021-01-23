    String input = "foo 6";
    String input1 = "foo :6";
    Regex rgx = new Regex(@"^(?<Text>(?:(?!:\d+).)+(?=$|\s+:(?<Number>\d+)$))");
     
    foreach (Match m in rgx.Matches(input))
    {
    Console.WriteLine(m.Groups["Text"].Value);
    }
    foreach (Match m in rgx.Matches(input1))
    {
    Console.WriteLine(m.Groups["Text"].Value);
    Console.WriteLine(m.Groups["Number"].Value);
    }
