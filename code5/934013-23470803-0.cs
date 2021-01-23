    private void RollDice() 
    {
        for (int i = 0; i < dice.Length; i++)
        {
            var currenRoll = roll.Next(1, 6);
            dice[i] += currentRoll;
            dicePictureBox.Image = diceImages[currentRoll];
         
            playerTotalLabel.Text = String.Format("Total: {0}", dice[i]);
        }
    }
