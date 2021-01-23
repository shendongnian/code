    private void message(GameResult result, RockPaperScissors choice1, RockPaperScissors choice2)
    {
        if (result == GameResult.Draw)
        {
            MessageBox.Show("It is a draw. Both chose " + choice1.ToString());                
        }
        else
        {
            string message = string.Format("Congratulations, {0} beats {1}!"
                , result == GameResult.PlayerOneWin ? choice1 : choice2
                , result == GameResult.PlayerOneWin ? choice2 : choice1);
            MessageBox.Show(message);
        }
    }
