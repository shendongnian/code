    var pat = new Regex(@"^A(B(C(.(Z)?)?)?)?");
    var testStrings = new string[]
    {
        "ALPHA",
        "ABGOOF",
        "ABCblah",
        "ABCbZ",
        "FOOBAR"
    };
    foreach (var s in testStrings)
    {
        var m = pat.Match(s);
        if (m.Success)
        {
            Console.WriteLine("{0} matches {1}", s, m.Value);
        }
        else
        {
            Console.WriteLine("No match found for {0}", s);
        }
    }
