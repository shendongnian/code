    String s = "123dfdf";
    if (!Regex.IsMatch(s, @"^[a-zA-Z_][a-zA-Z_\d]*$")) {
    Console.WriteLine("Error! Wrong format.");
    }
    else {
    Console.WriteLine("Correct format.");
    }
