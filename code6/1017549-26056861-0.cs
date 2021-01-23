    String input = @"department_name:womens AND item_type_keyword:base-layer-underwear";
    Regex rgx = new Regex(@"(?:(department_name:([\w-]+))|(item_type_keyword:([\w-]+)))");
    foreach (Match m in rgx.Matches(input))
    {
    Console.WriteLine(m.Groups[1].Value);
    Console.WriteLine(m.Groups[2].Value);
    Console.WriteLine(m.Groups[3].Value);
    Console.WriteLine(m.Groups[4].Value);
    }
