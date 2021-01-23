    void main()
    {
        Console.WriteLine("Hello. How are you?");
        string userValue = Console.ReadLine();
        string message = "";
        string[] goodWords = new string[] { "good", "well", "sweet", "brilliant"};
        string[] badWords  = new string[] { "terrible", "awful", "bad", "sucks"};   
        if (DoesStringContainAnyOf(userValue, goodWords))
            message = "That's good to hear. Do you want a cup of tea?";
        
        else if (DoesStringContainAnyOf(userValue, badWords))
            message = "I'm sorry to hear that. Shall I make you a coffee?";
        else
            message = "I don't understand. Do you want a cuppa?";
        string answer = "I'm really well thanks";        
    }
    bool DoesStringContainAnyOf(string searchIn, string[] wordsToFind)
    {
        foreach(string word in wordsToFind)
            if (searchIn.Contains(word))
                return true;
        return false;
    }
