    string userInput = Console.ReadLine();
    var letters = userInput
                 .Where(x => !char.IsWhiteSpace(x))
                 .Select(x => x.ToString()).ToArray();
    foreach (string[] permutation in Permutations<string>.AllFor(letters))
    {
        Console.WriteLine(string.Join(" ", permutation));
    }
