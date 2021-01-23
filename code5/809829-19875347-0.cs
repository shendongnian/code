    string input = " userid <= 'tom'";
    string text = string.Empty;
    if (Regex.Match(input, @"(?i)(<=|>=|<>|\|\||:=|&&|==|<|>|&|\+|-|\*|/|\?)").Success)
    {
        text = input;
        Console.WriteLine(text);
    }
    Console.ReadLine();
