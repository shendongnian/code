    private void btnGuess_Click(object sender, EventArgs e)
    {
        lblAnswer.Text = "";
        if (string.IsNullOrEmpty(txtGuess.Text)) // input validation check to make sure not blank
        {
            MessageBox.Show("Please enter a whole number between 1 and 100", "Error!!");
            return;
        } //end if
        if (!int.TryParse(txtGuess.Text, out UserGuess))
        {
            MessageBox.Show("Please enter a whole number between 1 and 100", "Error!!");
            return;
        }
        Guesses ++;
        if (UserGuess > Answer)
        {
            txtGuess.Text = "";
            lblAnswer.Text = "Too high, try again.";
        }
        else if (UserGuess < Answer)
        {
            txtGuess.Text = "";
            lblAnswer.Text = "Too low, try again.";
        }
        else
        {
            lblAnswer.Text = "Congratulations the answer was " + Answer + "!\nYou guessed the number in " + Guesses + " tries.\nTo play again click the clear button.";
        } //end if
    } 
