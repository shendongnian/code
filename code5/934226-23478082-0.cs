        private void RollDice()
        {
            bool gameComplete = false;
            for (int i = 0; i < dice.Length; i++)
            {
                var currentRoll = roll.Next(1, 7);
                if (currentRoll == 1)
                {
                    dice = new int[1] { 0 };
                    gameComplete = true;
                }
                else
                {
                    dice[i] += currentRoll;
                    dicePictureBox.Image = diceImages[currentRoll - 1];
                }
                playersTotal.Text = String.Format("{0}", dice[i]);
            }//end for
            if (gameComplete)
            {
                MessageBox.Show("Sorry you have thrown a 1. your turn is over!");
            }
