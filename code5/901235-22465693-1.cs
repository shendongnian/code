    bool keepGoing = true;
    for (int i = 0; keepGoing && i < 100; i++)
    {
        for (int j = 0; keepGoing && j < 10; j++)
        {
            if (i == 5)
            {
                keepGoing = false; // Stops both
            }
        }
    }
