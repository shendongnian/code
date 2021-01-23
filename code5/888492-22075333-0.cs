    GameBoard GetBestNextMove(GameBoard, recursiveDepth) {
        if (recursiveDepth == 0 || GameBoard.NoMovesRemaining()) return GameBoard;
        BestGameBoard = null;
        foreach (possibleMove) {
           GameBoard = GameBoard.Clone();
           GameBoard.MakeMove(possibleMove);
           GameBoard = GetBestNextMove(GameBoard, recursiveDepth - 1);
           if (GameBoard != null) {
             if (BestGameBoard == null) BestGameBoard = GameBoard;
             else if (GameBoard.Score > BestGameBoard) BestGameBoard = GameBoard;
           }
        }
        return BestGameBoard;
    }
