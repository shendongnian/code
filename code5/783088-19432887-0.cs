    int x = 1;
    
    // Both these lines are invalid because a string literal is not a complete statement:
    "x is an integer";
    x < 0 ? "x is Negative" : "x is not Negative";
    //Valid:
    string intDescription = "x is an integer";
    string describeNegative = x < 0 ? "x is Negative" : "x is not Negative";
    // Invalid because the ternary operator chooses between values, and Console.WriteLine
    // is void:
    x < 0 ? Console.WriteLine("x is Negative") : Console.WriteLine("x is not Negative");
    // Valid:
    Console.WriteLine(x < 0 ? "x is Negative" : "x is not Negative");
    // or:
    string describeNegative = x < 0 ? "x is Negative" : "x is not Negative";
    Console.WriteLine(describeNegative);
