    String input = @"1100x1200@60";
    Regex rgx = new Regex(@"(\d+)x(\d+)(?=@)");
    foreach (Match m in rgx.Matches(input))
    {
    String var1 = m.Groups[1].Value;
    String var2 = m.Groups[2].Value;
    Console.WriteLine(var1);
    Console.WriteLine(var2);
    }
