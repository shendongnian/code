    ...
    if (!Active_Word.Guess_Word.Contains(letter))
                {
                    listBIncorrectTrys.Items.Add(letter);
                    Active_Word.Wrong_Guess++;
                    // Something similar to this
                    // But try not to hard code constants like '6'
                    lbGuessesLeft.Text = 6 - Active_Word.Wrong_Guess;
                }
                lbGuessWord.Text = GetMaskedWord();
                Attempts_Made++;
    ...
