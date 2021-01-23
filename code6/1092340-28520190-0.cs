    foreach (string j in music)
    {
        Console.WriteLine(j);
        string read = Console.ReadLine(); // This blocks until the user presses 'enter'
        Console.WriteLine(read); // Just echo the response.
    }
