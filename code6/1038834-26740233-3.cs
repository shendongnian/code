    private void OnGameButton_Click(object sender, EventArgs e)
    {
        if (!hasGameStarted || shouldLoseTurn)
            return;
        // This is the current button user pressed
        Button b = (sender as Button);
        if (b.Name.Contains('A') && b.Enabled)
        {
            if (!b.Text.Equals(""))
            {
                MessageBox.Show("Not A Valid Input! You have lost your turn.");
                shouldLoseTurn = true;
            }
            else
            {
                b.Text = currentPlayersLetter;
                shouldLoseTurn = false;
            }
        }
    }
