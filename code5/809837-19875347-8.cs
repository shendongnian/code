    string pattern = "(?<=\")[^,]+?(?=\")";
    string patternSpecial = @"^.+?(<=|>=|<>|\|\||:=|&&|==|<|>|&|\+|-|\*|/|\?).+?$";
    string input = "if(a<=b, strcat(\" userid <= 'tom' \",\" and test = 1\", \" and test >= 10 \"), nop());";  
    foreach (Match m in Regex.Matches(input, pattern))
    {
        if (Regex.IsMatch(m.Value, patternSpecial))
        {
            Console.WriteLine(Regex.Match(m.Value, patternSpecial).Value);
        }
    }
    Console.ReadLine();
