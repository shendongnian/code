    static IChessGame MovePiece(IChessGame oldState, IChessPiece chessPiece, int[,] newLocation)
    {
        // Check the chess piece.
        // See if the new coordinates are allowed for that piece.
        // Deal with any collisions (e.g. if an opponents piece is in the square then kill it, if it's your piece then block the move, etc.)
        // Generate a new, allowed, state
    }
