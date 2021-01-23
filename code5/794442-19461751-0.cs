    // Make sure the indexes of the arrays are aligned with the player array 
    // (to keep track which points are for which player)
    int[] playerNums = new int[10];
    string[] playerNames = new string[10];
    int[] playerPoints = new int[10];
    // We now add the user here (you do it somewhere from user input)
    playerNums[0] = 1;
    playerNames[0] = "Tim";
    playerPoints[0] = 10;
    char key = Console.ReadKey(true).KeyChar;
    if (char.IsDigit(key))
    {
        // We get the number from the char.
        int inputNum = int.Parse(key.ToString());
        // We make sure the user isn't giving an index past the length of our arrays
        // (which are 10 in size).
        if (inputNum > -1 && inputNum < playerNums.Length - 1)
        {
            playerNames[inputNum] = "John"; // Tim now becomes John.
            playerPoints[inputNum] += 5; // Increase John's score.
        }
    }
