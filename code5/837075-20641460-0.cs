    string[] names = { "Brendán", "Jóhn", "Jason" };
    Regex rgx      = new Regex(@"^\p{L}+$");
    foreach (string name in names)
        Console.WriteLine("{0} {1} a valid name.", name, rgx.IsMatch(name) ? "is" : "is not");
    // Brendán is a valid name.
    // Jóhn is a valid name.
    // Jason is a valid name.
