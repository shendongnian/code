    string input = "Hello &|&&|& complicated world!";
    string[] singleCharReplaceables = new[] { "+", "!", "(", ")", "{", "}", "[", "]", "^", "~", "*", "?", ":", "\\", "\"" };
    string[] multipleCharReplaceables = new[] { "&&", "||" };
    string output = input;
    foreach (string r in singleCharReplaceables)
        output = output.Replace(r, string.Empty);
    string outputRef = output;
    do
    {
        outputRef = output;
        foreach (string r in multipleCharReplaceables)
            output = output.Replace(r, string.Empty);
    } while (output != outputRef);
    Console.WriteLine(output); // Hello complicated world
