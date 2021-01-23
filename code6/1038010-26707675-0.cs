    private void guessButton_Click(object sender, EventArgs e)
    {
        answer = Convert.ToInt32(GuessBox.Text);
        if (answer == rando[counter1+counter2])
        {
            counter2++;
            label2.Text = "The number of correct guesses is: " + counter2;
        }
        else (answer != rando[i])
        {
            counter1++;
            label3.Text = "The number if incorrect guesses is: " + counter1;
        }
        nextGuess.Enabled = true;
        guessButton.Enabled = false;
        GuessBox.Clear();
    }
