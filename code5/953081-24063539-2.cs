    public void deal() //iam having trouble how to write this function
    {
        // deal the deck
        for (int i = 0; i < numPlayers; i++)
        {
            for (int j = 0; j < hand; j++)
            {
                players[i, j] = RemoveTopCard();
            }
        }
    }
