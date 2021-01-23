    int userInput;
    string userString;
    Console.WriteLine("Would you like to replace a card?");
    Console.WriteLine("Select which card you would like to replace, 1-5. Enter 0 to skip");
    userString = Console.ReadLine();
    int.TryParse(userString, out userInput);
    while (userInput != 0)
    {
        switch (userInput)
        {
            case 1:
                userInput--;
                userHand[userInput] = cardDeck.GetOneCard();
                break;
            case 2:
                userInput--;
                userHand[userInput] = cardDeck.GetOneCard();
                break;
            case 3:
                userInput--;
                userHand[userInput] = cardDeck.GetOneCard();
                break;
            case 4:
                userInput--;
                userHand[userInput] = cardDeck.GetOneCard();
                break;
            case 5:
                userInput--;
                userHand[userInput] = cardDeck.GetOneCard();
                break;
            default:
                Console.WriteLine("Incorrect input, try again");
                break;
        }
    Console.WriteLine("Select which card you would like to replace, 1-5. Enter 0 to skip");
    userString = Console.ReadLine();
    int.TryParse(userString, out userInput);
    }
