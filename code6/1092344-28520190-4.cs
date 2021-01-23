    string[] music = new string[4];
    // ... populate music
    string[] expectedResponses = new string[music.Length];
    // ... populate expected responses
    for (int i = 0; i < music.Length; i++)
    {
        string j = music[i];
        string expectedResponse = expectedResponses[i];
        string actualResponse = Console.ReadLine();
        if(actualResponse == expectedResponse) // you might want to do something about casing here
        {
            Console.WriteLine("Correct!");
        }
        else
        { 
            Console.WriteLine("Incorrect.");
        }
    }
