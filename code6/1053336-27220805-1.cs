    string text = "-124";
    int num;
    Regex intRegex = new Regex(@"^(\+|-)?\d+$");
    if (intRegex.IsMatch(text))
        num = Int32.Parse(text);
    else
        Console.WriteLine("Unfortunately, the program has crashed and burned.");
