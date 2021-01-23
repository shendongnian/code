    string userInput = Console.ReadLine();
    int index = userInput.IndexOf(','); // get the index of first comma
    while (index != -1) // keep going until there is no comma
    {
        // display the current value of userInput
        Console.WriteLine(userInput); 
        // update the value of userInput
        userInput = userInput.Substring(index + 1).Trim(); 
        // update the value of index
        index = userInput.IndexOf(',');
    }
    Console.WriteLine(userInput); // display the last part
