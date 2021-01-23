    public class Board {
        public Piece[] Pieces { get; set; }
        public Board() {
             Pieces = new Piece[64];
             // Setup initial pawns
             for (int x = 8; x < 16; x++)
             {
                  Pieces[x].PieceColor = PieceColors.White;
                  Pieces[x].PieceType = PieceTypes.Pawn;
             }
        }
    }
