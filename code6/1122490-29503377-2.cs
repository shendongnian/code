    ...
    if (!Active_Word.Guess_Word.Contains(letter))
                {
                    listBIncorrectTrys.Items.Add(letter);
                    Active_Word.Wrong_Guess++;
                    // Something similar to this
                    lbGuessesLeft.Text = 6 - Active_Word.Wrong_Guess;
                }
                lbGuessWord.Text = GetMaskedWord();
                Attempts_Made++;
