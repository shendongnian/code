    public void SetBoardSize(int width, int height) {
        builder = new GameBoardBuilder(width, height);
    }
    
    public bool IsBoardValid() { return builder != null && builder.IsValid(); }
    
    public void StartGame() {
        var gameBoard = builder.MakeGameBoard();
        ...
    }
