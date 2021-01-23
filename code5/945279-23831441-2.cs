    private IEnumerable<Piece> GetAllPieces()
    {
        // enumerate all child controls which are of type 'Piece'
        return this
            .Controls
            .Cast<Control>()
            .Select(c => c as Piece)
            .Where(c => c != null);
    }
