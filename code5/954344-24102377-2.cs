    public enum PieceColors {
        Black,
        White
    }
    public enum PieceTypes {
        Rook,
        Pawn,
        Knight,
        Queen,
        King,
        Bishop
    }
    public class Piece {
        public PieceTypes PieceType { get; set; };
        public PieceColors PieceColor { get; set; };
        public Bitmap GetPieceBitmap()
        {
            // Return a Bitmap representing the piece based on PieceType and PieceColor
        }
    }
