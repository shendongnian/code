    Dictionary<string, string> responses = new Dictionary<string, string>();
    foreach (string j in music)
    {
        Console.WriteLine(j);
        string read = Console.ReadLine(); // This blocks until the user presses 'enter'
        responses[j] = read;
    }
