    string input = "2974.23abcdefs";
    decimal d;
    char decSep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0]; // there is no culture with a decimal-separator that has more than one letter so this isn't harmful
    if(!string.IsNullOrEmpty(input) && Char.IsDigit(input[0]))
    {
        string number = string.Concat(input.TakeWhile(c => Char.IsDigit(c) || decSep == c));
        bool validDecimal = decimal.TryParse(number, out d);
        Console.WriteLine("Valid? {0} Parsed to: {1}", validDecimal, d);
    }
