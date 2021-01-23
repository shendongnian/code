    string s = "\U0001D11E";
    foreach (var b in Encoding.UTF32.GetBytes(s))
        Console.WriteLine(b.ToString("x2"));
    Console.WriteLine();
    foreach (var b in Encoding.Unicode.GetBytes(s))
        Console.WriteLine(b.ToString("x2"));
    > 1e
    > d1
    > 01
    > 00
    >
    > 34
    > d8
    > 1e
    > dd
