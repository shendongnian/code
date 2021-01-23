    string input = @"\test";
    bool result = !Regex.IsMatch(input, @"[""'\\]+");
    //                                     ^^
    // You need to double the double-quotes when working with verbatim strings;
    // All other characters, including backslashes, remain unchanged.
    if (!result) {
        Console.WriteLine("Comments cannot contain quotes (double or single) or slashes.");
    }
