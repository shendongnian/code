    var r = new RegularExpressionAttribute(@"[^123]*");
    Console.WriteLine(r.IsValid("ABC3DEF")); // false
    Console.WriteLine(r.IsValid("ABC4DEF")); // true
    Console.WriteLine(r.IsValid("ABC")); // true
    Console.WriteLine(r.IsValid("ABC1")); // false
    Console.WriteLine(r.IsValid("ABC123")); // false
