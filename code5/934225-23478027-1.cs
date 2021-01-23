    Image[] diceImages;
    int dice = 0; // array removed because it is not needed
    Random roll = new Random(); 
    private void rollDieBotton_Click(object sender, EventArgs e) {
        RollDice();
        Pig.Hold();
    
        if (dice == 1)
        {
        playAnotherGameLabel.Text = "0";
        MessageBox.Show("Sorry you have thrown a 1. your turn is over!");
        }
    }
    private void RollDice() {
        // for loop is not needed because it is no longer an array
            var currentRoll = roll.Next(1, 7);
            dice[i] += currentRoll; // this in my opinion should be = not += because the result of the next roll will be absurd
            dicePictureBox.Image = diceImages[currentRoll-1];
            playersTotal.Text = String.Format("{0}", dice[i]);
            
    } // end RollDice
