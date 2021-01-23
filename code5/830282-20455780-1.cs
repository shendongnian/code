    private void RockButton_Click(object sender, RoutedEventArgs e)
    {
        engine.PlayerMove = GameEngine.Move.Rock;
        displayResult();
    }
    private void PaperButton_Click(object sender, RoutedEventArgs e)
    {
        engine.PlayerMove = GameEngine.Move.Paper;
        displayResult();
    }
    private void ScissorButton_Click(object sender, RoutedEventArgs e)
    {
        engine.PlayerMove = GameEngine.Move.Scissor;
        displayResult();
    }
    private void displayResult()
    {
        switch(engine.Result)
        {
            case GameEngine.MoveResult.Draw:
                //Display message and change color
                break;
            case GameEngine.MoveResult.PlayerWon:
                break;
            case GameEngine.MoveResult.ComputerWon:
                break;
        }
    }
