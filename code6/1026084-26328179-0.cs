            for (int i = 0; i < guessThis.Length - 1; i++ )
            {
                //check if the element matches the user guess
                if (c == userGuess[i])
                {
                    //insert the userguess into the index
                    displayAnswer[i] = userGuess;
                }
            }
