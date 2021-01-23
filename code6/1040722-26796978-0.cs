    private void btnClear_Click(object sender, EventArgs e)  // clears Answer label and Guess textbox
    {
        txtGuess.Text = ""; // to reset the TextBox
        lblAnswer.Text = ""; // to reset the Label
        Random rand = new Random(); // Doesn't it make Answer to be always the same integer?
        Answer = rand.Next(100) + 1; // to generate a new random answer
        Guesses = 0; // to reset the number of guesses
    }
